﻿using BF1ServerTools.Data;
using BF1ServerTools.Models;

namespace BF1ServerTools.Views.Rule;

/// <summary>
/// GeneralView.xaml 的交互逻辑
/// </summary>
public partial class GeneralView : UserControl
{
    /// <summary>
    /// 绑定UI 队伍1规则集
    /// </summary>
    public RuleGeneralModel RuleGeneral1Model { get; set; } = new();
    /// <summary>
    /// 绑定UI 队伍2规则集
    /// </summary>
    public RuleGeneralModel RuleGeneral2Model { get; set; } = new();

    ////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 获取队伍1当局规则数据委托
    /// </summary>
    public static Func<GeneralData> FuncGetTeam1GeneralData;
    /// <summary>
    /// 获取队伍2当局规则数据委托
    /// </summary>
    public static Func<GeneralData> FuncGetTeam2GeneralData;

    /// <summary>
    /// 设置队伍1当局规则数据委托
    /// </summary>
    public static Action<GeneralData> ActionSetTeam1GeneralData;
    /// <summary>
    /// 设置新队伍2当局规则数据委托
    /// </summary>
    public static Action<GeneralData> ActionSetTeam2GeneralData;

    ////////////////////////////////////////////////////////////////////

    public GeneralView()
    {
        InitializeComponent();

        FuncGetTeam1GeneralData = GetTeam1GeneralData;
        FuncGetTeam2GeneralData = GetTeam2GeneralData;

        ActionSetTeam1GeneralData = SetTeam1GeneralData;
        ActionSetTeam2GeneralData = SetTeam2GeneralData;

        RuleView.ApplyCurrentRuleEvent += RuleView_ApplyCurrentRuleEvent;
    }

    private void RuleView_ApplyCurrentRuleEvent()
    {
        ApplyCurrentRule();
    }

    private void ApplyCurrentRule()
    {
        Globals.ServerRule_Team1.MaxKill = RuleGeneral1Model.MaxKill;
        Globals.ServerRule_Team1.FlagKD = RuleGeneral1Model.FlagKD;
        Globals.ServerRule_Team1.MaxKD = RuleGeneral1Model.MaxKD;
        Globals.ServerRule_Team1.FlagKPM = RuleGeneral1Model.FlagKPM;
        Globals.ServerRule_Team1.MaxKPM = RuleGeneral1Model.MaxKPM;
        Globals.ServerRule_Team1.MinRank = RuleGeneral1Model.MinRank;
        Globals.ServerRule_Team1.MaxRank = RuleGeneral1Model.MaxRank;

        Globals.ServerRule_Team2.MaxKill = RuleGeneral2Model.MaxKill;
        Globals.ServerRule_Team2.FlagKD = RuleGeneral2Model.FlagKD;
        Globals.ServerRule_Team2.MaxKD = RuleGeneral2Model.MaxKD;
        Globals.ServerRule_Team2.FlagKPM = RuleGeneral2Model.FlagKPM;
        Globals.ServerRule_Team2.MaxKPM = RuleGeneral2Model.MaxKPM;
        Globals.ServerRule_Team2.MinRank = RuleGeneral2Model.MinRank;
        Globals.ServerRule_Team2.MaxRank = RuleGeneral2Model.MaxRank;
    }

    /// <summary>
    /// 获取队伍1当局规则数据
    /// </summary>
    /// <returns></returns>
    private GeneralData GetTeam1GeneralData()
    {
        return new GeneralData
        {
            MaxKill = RuleGeneral1Model.MaxKill,
            FlagKD = RuleGeneral1Model.FlagKD,
            MaxKD = RuleGeneral1Model.MaxKD,
            FlagKPM = RuleGeneral1Model.FlagKPM,
            MaxKPM = RuleGeneral1Model.MaxKPM,
            MinRank = RuleGeneral1Model.MinRank,
            MaxRank = RuleGeneral1Model.MaxRank
        };
    }

    /// <summary>
    /// 获取队伍2当局规则数据
    /// </summary>
    /// <returns></returns>
    private GeneralData GetTeam2GeneralData()
    {
        return new GeneralData
        {
            MaxKill = RuleGeneral2Model.MaxKill,
            FlagKD = RuleGeneral2Model.FlagKD,
            MaxKD = RuleGeneral2Model.MaxKD,
            FlagKPM = RuleGeneral2Model.FlagKPM,
            MaxKPM = RuleGeneral2Model.MaxKPM,
            MinRank = RuleGeneral2Model.MinRank,
            MaxRank = RuleGeneral2Model.MaxRank
        };
    }

    /// <summary>
    /// 设置队伍1当局规则数据
    /// </summary>
    /// <returns></returns>
    private void SetTeam1GeneralData(GeneralData generalData)
    {
        RuleGeneral1Model.MaxKill = generalData.MaxKill;
        RuleGeneral1Model.FlagKD = generalData.FlagKD;
        RuleGeneral1Model.MaxKD = generalData.MaxKD;
        RuleGeneral1Model.FlagKPM = generalData.FlagKPM;
        RuleGeneral1Model.MaxKPM = generalData.MaxKPM;
        RuleGeneral1Model.MinRank = generalData.MinRank;
        RuleGeneral1Model.MaxRank = generalData.MaxRank;
    }

    /// <summary>
    /// 设置队伍2当局规则数据
    /// </summary>
    /// <returns></returns>
    private void SetTeam2GeneralData(GeneralData generalData)
    {
        RuleGeneral2Model.MaxKill = generalData.MaxKill;
        RuleGeneral2Model.FlagKD = generalData.FlagKD;
        RuleGeneral2Model.MaxKD = generalData.MaxKD;
        RuleGeneral2Model.FlagKPM = generalData.FlagKPM;
        RuleGeneral2Model.MaxKPM = generalData.MaxKPM;
        RuleGeneral2Model.MinRank = generalData.MinRank;
        RuleGeneral2Model.MaxRank = generalData.MaxRank;
    }

    /// <summary>
    /// 队伍1最低等级规则调整事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Slider_Team1MinRank_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (RuleGeneral1Model.MaxRank == 0)
            return;

        if (RuleGeneral1Model.MinRank >= RuleGeneral1Model.MaxRank)
        {
            RuleGeneral1Model.MinRank = RuleGeneral1Model.MaxRank - 1;
        }
    }

    /// <summary>
    /// 队伍2最低等级规则调整事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Slider_Team2MinRank_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (RuleGeneral2Model.MaxRank == 0)
            return;

        if (RuleGeneral2Model.MinRank >= RuleGeneral2Model.MaxRank)
        {
            RuleGeneral2Model.MinRank = RuleGeneral2Model.MaxRank - 1;
        }
    }
}
