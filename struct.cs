    //define some struct
    
    public struct APCI_DATA         //遥信、遥测
    {
        public char calltype;				    //总召或分组召唤
        public short InfoAddr;			//YX YC 信息体地址
        public char apci_crc;				    //apci校验码
        public char apci_End;			       //apci真结束标志
    }

    public struct APCIDataInfo           //处理遥信、遥测
    {
        public APCI_ASDU ASDU_obj;            //APCI数据单元obj
        public APCI_DATA DATA_obj;              //APCI数据信息obj
    }
