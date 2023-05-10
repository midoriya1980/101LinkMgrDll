using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Power2000.General.CommTools;

namespace Power2000.CommuCfg
{
    public struct APCI_HEAD_ASDU           //处理遥信、遥测
    {
        public APCIFrameHead head;
        public APCI_ASDU ASDU;            // 数据单元
    }
    public class CLinklayerMgr : PtlmoduleMgr
    {
        public static short wSendSN = 0;//发送序列号
        public static short wRecvSN = 0;//接收序列号
        public static short count_I = 0;//I帧总数
        public static short sendConfirmCount = 0;//已确认I帧数

        public bool m_bMain;							// 是否为主通道      
        public int m_SConferm_Timer;					// S型确认帧发送倒数计时器
        public int m_UTest_Timer;						// U型测试帧发送倒数计时器
        public int m_UCon_TimeOff;						// U型帧测试确认倒数计时器

        //public event RtDataReportEventHandler RtDataReportEvent;
        //public event LinkEventHandler LinkEvent;

        private static CLinklayerMgr instance;
        public static CLinklayerMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CLinklayerMgr();
                }
                return instance;
            }
        }

        public short nSendSN
        {
            get { return wSendSN; }
        }

        public short nRecvSN
        {
            get { return wRecvSN; }
        }

        public void SetNotifySendSN()
        {
            wSendSN += 2;            
        }

        public void SetNotifyRecvSN()
        {
            wRecvSN += 2;
        }

        public void ResetSN()
        {
            wRecvSN = 0;
            wSendSN = 0;
            sendConfirmCount = 0;
            count_I = 0;
        }

        public void SetCountAPCI_I()
        {
            count_I++;
        }       

        public void SetSendConfirmCount(short value)
        {
            sendConfirmCount = (short)(value>>1);
        }       

        public void RebuiltLinklayer()
        {
            ResetSN();
            InitialLinkLayer();
        }      

        /*
        * 发送104传输原因、公共地址、信息体地址（223），下发功能定值
        * */
        public void SendConfirm_U()
        {
            APCIFrameHead uFrameInfo = new APCIFrameHead();
            uFrameInfo.symbol = START_SYMBOL;
            uFrameInfo.length = (byte)(Marshal.SizeOf(uFrameInfo.ctlreg));
            uFrameInfo.ctlreg.wctlSN = APCI_TESTFR_Con;//0x43;
            SendFrame(uFrameInfo,null,0);
            SConfigForm.Instance.t2 = 0;
        }

        /*
         * 发送文件操作召唤
         * */
        public void SendConfirm_S()
        {
            if(count_I == sendConfirmCount)
                return;
            APCIFrameHead sFrameInfo = new APCIFrameHead();
            sFrameInfo.symbol = START_SYMBOL;
            sFrameInfo.length = (byte)(Marshal.SizeOf(sFrameInfo.ctlreg));
            sFrameInfo.ctlreg.wctlSN = APCI_S;
            sFrameInfo.ctlreg.wctlRN = nRecvSN;
            SendFrame(sFrameInfo, null, 0);
            IsRecvFinished = false;
            SetSendConfirmCount(nRecvSN);
            SConfigForm.Instance.t2 = 0;
            SConfigForm.Instance.t0 = 0;
        }

        /*
         * 发送命令给下位机,针对U帧、S帧、I帧
         * */
        public void SendFrame(APCIFrameHead head, byte[]SendArray, int nLen)
        {
            IntPtr sendBuf = Marshal.AllocCoTaskMem(bufLen);
            if (sendBuf == IntPtr.Zero)
                return;

            Marshal.StructureToPtr(head, sendBuf, false);
            int sendLen = 0;

            sendLen = Marshal.SizeOf(head);
            
            byte[] sendByteArray = new byte[bufLen];
            for (int i = 0; i < sendLen; i++)
            {
                sendByteArray[i] = Marshal.ReadByte(sendBuf, i);
            }
            byte[] sendArr = new byte[sendLen + nLen];
            Array.Copy(sendByteArray, 0, sendArr, 0, sendLen);
            if (nLen > 0)
            {
                Array.Copy(SendArray, 0, sendArr, sendLen, nLen);
            }

            string s = SendDataFormat(sendArr);
            if (SConfigForm.Instance.IsOpenLog)
            {
                Log.FileName = DocumentMgr.Instance.LogFilePath + "配网终端收发报文.log";
                Log.Report(LogLevel.Info, "", s);
                //WriteFile("messagelog.log", s);//报文日志功能
            }

            ShowSendInfo(sendArr);
            try
            {
                rtClient.BeginSend(sendArr, 1000, sendLen + nLen);
                rtClient.BeginReceive(0);
            }
            catch (SocketException e)
            {
                Log.Report(LogLevel.Exception, "配网自动化终端综合维护软件", String.Format("Socket异常 错误码：{0}", e.ErrorCode));
            }
        }        

        /*
         * 链路初始化
         * */
        public override void InitialLinkLayer()
        {
            ResetSN();
            APCIFrameHead head = new APCIFrameHead();
            head.symbol = START_SYMBOL;
            head.length = (byte)Marshal.SizeOf(head.ctlreg);
            head.ctlreg.wctlSN = 0x07;//0x43;
            SendFrame(head,null,0);
            IsAllCallUpFinished = true;
        }

        public bool OnRecvData(byte[] RecvData)
        {     
            SConfigForm.Instance.t0 = 0;
            int nLength = RecvData.Length;
            IntPtr ptr = Marshal.AllocHGlobal(RecvData.Length);
            unsafe
            {
                Marshal.Copy(RecvData, 0, ptr, sizeof(APCIFrameHead));
            }
            APCIFrameHead head = (APCIFrameHead)Marshal.PtrToStructure(ptr, typeof(APCIFrameHead));
            Marshal.FreeHGlobal(ptr);            
            
            int dataLen = head.length + Marshal.SizeOf(typeof(short));
            byte[] recvArray = new byte[dataLen];
            Array.Copy(RecvData, 0, recvArray, 0, dataLen);
            string s = RecvDataFormat(recvArray);

            if (SConfigForm.Instance.IsOpenLog)
            {
                //WriteFile("messagelog.log", s);//报文日志功能
                Log.FileName = DocumentMgr.Instance.LogFilePath + "配网终端收发报文.log";
                Log.Report(LogLevel.Info, "", s);
            }

            ShowRecvInfo(recvArray);

            if (DealwithAPCI_U(head))
            {
                return IsRecvFinished;
            }
            else
            {
                IsRecvFinished = true;
                CApplicationlayer.Instance.ParseFrame(recvArray);                
            }

            return false;
        }

        public bool DealwithAPCI_U(APCIFrameHead head)
        {
            bool isUFrame = false;
           if((head.ctlreg.wctlSN & 0x01) == APCI_I)
            {
                CLinklayerMgr.Instance.SetCountAPCI_I();
                CLinklayerMgr.Instance.SetNotifyRecvSN();
                if ((count_I - sendConfirmCount) % 8 == 0 && count_I != 0)
                {
                    SendConfirm_S();
                }
           }
           else if ((head.ctlreg.wctlSN & 0x03) == APCI_S)
           {
               isUFrame = true;
           }
           else if ((head.ctlreg.wctlSN & 0x03) == APCI_U)
           {
               isUFrame = true;
               if (head.ctlreg.wctlSN == APCI_TESTFR_Act)
                {
                    SendConfirm_U();
                }
               else if (head.ctlreg.wctlSN == APCI_STOPDT_Act)
                {
                    InitialLinkLayer();
                }
           }
            return isUFrame;
        }

        public void DealwithAPCI_S()
        {

        }

        public void DealwithAPCI_I()
        {
            SendConfirm_S();
        }
        //END REGION
    }

    
}
