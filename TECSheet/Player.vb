Imports System.Runtime.Serialization
Imports System.Collections.Generic

<Serializable()>
Public Enum Stat
    STR
    DEX
    MND
    LCK
End Enum

<Serializable()>
Public Class Player

    Public Name As String,
        STR As Integer,
        DEX As Integer,
        MND As Integer,
        LCK As Integer,
        HPTemp As Integer,
        HPTot As Integer,
        MPTemp As Integer,
        MPTot As Integer,
        PPTemp As Integer,
        PPTot As Integer,
        LPTemp As Integer,
        LPTot As Integer,
        KPTemp As Integer,
        KPTot As Integer,
        DodgeBonus As Integer,
        PerceptionBonus As Integer,
        HitBonus As Integer,
        Attack1Bonus As Integer,
        Dmg1Stat As Stat,
        Dmg1Bonus As Integer,
        Dmg1DieCount As Integer,
        DMG1DieSides As Integer,
        Attack2Bonus As Integer,
        Dmg2Stat As Stat,
        Dmg2Bonus As Integer,
        Dmg2DieCount As Integer,
        Dmg2DieSides As Integer,
        Roll1Bonus As Integer,
        Roll1DieCount As Integer,
        Roll1DieSides As Integer,
        Roll2Bonus As Integer,
        Roll2DieCount As Integer,
        Roll2DieSides As Integer,
        ArmorRT As Integer,
        ArmorRR As Integer,
        ArmorMisc As Integer,
        APCurrent As Integer,
        APTotal As Integer,
        APNormalGain As Integer,
        APStraightGain As Integer,
        Inventory As List(Of InventoryItem),
        Abilities As List(Of AbilityItem)

    Public Sub New(Optional mName As String = "",
        Optional sSTR As Integer = 0,
        Optional sDEX As Integer = 0,
        Optional sMND As Integer = 0,
        Optional sLCK As Integer = 0,
        Optional sHPTemp As Integer = 0,
        Optional sHPTot As Integer = 0,
        Optional sMPTemp As Integer = 0,
        Optional sMPTot As Integer = 0,
        Optional sPPTemp As Integer = 0,
        Optional sPPTot As Integer = 0,
        Optional sLPTemp As Integer = 0,
        Optional sLPTot As Integer = 0,
        Optional sKPTemp As Integer = 0,
        Optional sKPTot As Integer = 0,
        Optional sDodgeBonus As Integer = 0,
        Optional sPerceptionBonus As Integer = 0,
        Optional sHitBonus As Integer = 0,
        Optional sAttack1Bonus As Integer = 0,
        Optional sDmg1Stat As Stat = 0,
        Optional sDmg1Bonus As Integer = 0,
        Optional sDmg1DieCount As Integer = 0,
        Optional sDMG1DieSides As Integer = 0,
        Optional sAttack2Bonus As Integer = 0,
        Optional sDmg2Stat As Stat = 0,
        Optional sDmg2Bonus As Integer = 0,
        Optional sDmg2DieCount As Integer = 0,
        Optional sDmg2DieSides As Integer = 0,
        Optional sRoll1Bonus As Integer = 0,
        Optional sRoll1DieCount As Integer = 0,
        Optional sRoll1DieSides As Integer = 0,
        Optional sRoll2Bonus As Integer = 0,
        Optional sRoll2DieCount As Integer = 0,
        Optional sRoll2DieSides As Integer = 0,
        Optional sArmorRT As Integer = 0,
        Optional sArmorRR As Integer = 0,
        Optional sArmorMisc As Integer = 0,
        Optional sAPCurrent As Integer = 0,
        Optional sAPTotal As Integer = 0,
        Optional sAPNormalGain As Integer = 0,
        Optional sAPStraightGain As Integer = 0,
        Optional sInventory As List(Of InventoryItem) = Nothing,
        Optional sAbilities As List(Of AbilityItem) = Nothing)
        Name = mName
        STR = sSTR
        DEX = sDEX
        MND = sMND
        LCK = sLCK
        HPTemp = sHPTemp
        HPTot = sHPTot
        MPTemp = sMPTemp
        MPTot = sMPTot
        PPTemp = sPPTemp
        PPTot = sPPTot
        LPTemp = sLPTemp
        LPTot = sLPTot
        KPTemp = sKPTemp
        KPTot = sKPTot
        DodgeBonus = sDodgeBonus
        PerceptionBonus = sPerceptionBonus
        HitBonus = sHitBonus
        Attack1Bonus = sAttack1Bonus
        Dmg1Stat = sDmg1Stat
        Dmg1Bonus = sDmg1Bonus
        Dmg1DieCount = sDmg1DieCount
        DMG1DieSides = sDMG1DieSides
        Attack2Bonus = sAttack2Bonus
        Dmg2Stat = sDmg2Stat
        Dmg2Bonus = sDmg2Bonus
        Dmg2DieCount = sDmg2DieCount
        Dmg2DieSides = sDmg2DieSides
        Roll1Bonus = sRoll1Bonus
        Roll1DieCount = sRoll1DieCount
        Roll1DieSides = sRoll1DieSides
        Roll2Bonus = sRoll2Bonus
        Roll2DieCount = sRoll2DieCount
        Roll2DieSides = sRoll2DieSides
        ArmorRT = sArmorRT
        ArmorRR = sArmorRR
        ArmorMisc = sArmorMisc
        APCurrent = sAPCurrent
        APTotal = sAPTotal
        APNormalGain = sAPNormalGain
        APStraightGain = sAPStraightGain
        Inventory = If(sInventory, New List(Of InventoryItem)())
        Abilities = If(sAbilities, New List(Of AbilityItem)())
    End Sub

    Public Sub New()

    End Sub

End Class
