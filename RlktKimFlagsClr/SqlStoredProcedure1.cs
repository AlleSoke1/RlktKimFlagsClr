using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    enum EFlags
    {
        FLAG_BIT_FASHION = 0,
        FLAG_BIT_VESTED = 1,
        FLAG_BIT_CAN_ENCHANT = 2,
        FLAG_BIT_CAN_USE_INVENTORY = 3,
        FLAG_BIT_NO_EQUIP = 4,
        FLAG_BIT_IS_PC_BANG = 5,
        FLAG_BIT_CAN_HYPER_MODE = 6,
        FLAG_BIT_HIDE_SET_DESC = 7,
        FLAG_POS_USE_TYPE = 8,
        FLAG_NUM_USE_TYPE = 4,
        FLAG_POS_USE_CONDITION = 12,
        FLAG_NUM_USE_CONDITION = 4,
        FLAG_POS_ITEM_TYPE = 16,
        FLAG_NUM_ITEM_TYPE = 4,
        FLAG_POS_ITEM_GRADE = 20,
        FLAG_NUM_ITEM_GRADE = 4,
        FLAG_POS_PERIOD_TYPE = 24,
        FLAG_NUM_PERIOD_TYPE = 4,
        FLAG_POS_SHOP_PRICE_TYPE = 28,
        FLAG_NUM_SHOP_PRICE_TYPE = 4,
    };//
    enum EFlags2
    {
        FLAG_BIT_PVP_ITEM = 0,
    };//

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetFlag (int dwFlags, int nFlagBit)
    {
       return (dwFlags & (1 << nFlagBit));
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetValue(int dwFlags, int dwBitPos, int dwNumBits)
    {
        return (dwFlags >> dwBitPos) & ((1 << dwNumBits) - 1);
    }
    public static int    _GetBit(int m_dwFlags, int dwBitPos )  { return ( m_dwFlags & (1<<dwBitPos) ) != 0 ? 1 : 0; }

    public static int _GetValue(int m_dwFlags, int dwBitPos, int dwNumBits) 
    {
        return  (m_dwFlags >> dwBitPos) & ((1<<dwNumBits) - 1 );
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsFashion(int m_dwFlags) { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_FASHION); }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsVested(int m_dwFlags) { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_VESTED); }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsHideSetDesc(int m_dwFlags)                           { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_HIDE_SET_DESC ); }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsPvpItem(int m_dwFlags)                               { return _GetBit(m_dwFlags, (int)EFlags2.FLAG_BIT_PVP_ITEM ); }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsCanEnchant(int m_dwFlags)                            { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_CAN_ENCHANT ); }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsCanUseInventory(int m_dwFlags)                       { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_CAN_USE_INVENTORY ); }
 
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsNoEquip(int m_dwFlags)                               { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_NO_EQUIP ); }
  
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsIsPcBang(int m_dwFlags)                              { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_IS_PC_BANG ); }
 
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int IsCanHyperMode(int m_dwFlags)                          { return _GetBit(m_dwFlags, (int)EFlags.FLAG_BIT_CAN_HYPER_MODE ); }
 
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetUseType(int m_dwFlags)                              { return _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_USE_TYPE, (int)EFlags.FLAG_NUM_USE_TYPE); }
 
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetUseCondition(int m_dwFlags)                    { return _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_USE_CONDITION, (int)EFlags.FLAG_NUM_USE_CONDITION); }
  
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetItemType(int m_dwFlags)                            { return  _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_ITEM_TYPE, (int)EFlags.FLAG_NUM_ITEM_TYPE); }
 
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetItemGrade(int m_dwFlags)                          { return  _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_ITEM_GRADE, (int)EFlags.FLAG_NUM_ITEM_GRADE); }
  
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetPeriodType(int m_dwFlags)                        { return  _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_PERIOD_TYPE, (int)EFlags.FLAG_NUM_PERIOD_TYPE); }
   
    [Microsoft.SqlServer.Server.SqlFunction]
    public static int GetShopPriceType(int m_dwFlags)                 { return  _GetValue(m_dwFlags, (int)EFlags.FLAG_POS_SHOP_PRICE_TYPE, (int)EFlags.FLAG_NUM_SHOP_PRICE_TYPE); }

}
