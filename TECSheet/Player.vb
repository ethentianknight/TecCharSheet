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
        Dmg1Stat As tat,
        Dmg1Bonus As Integer,
        Dmg1DieCount As Integer,
        DMG1DieSides As Integer,
        Attack2Bonus As Integer,
        Dmg2Stat As tat,
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

    Public Sub New(mName As String,
        sSTR As Integer,
        sDEX As Integer,
        sMND As Integer,
        sLCK As Integer,
        sHPTemp As Integer,
        sHPTot As Integer,
        sMPTemp As Integer,
        sMPTot As Integer,
        sPPTemp As Integer,
        sPPTot As Integer,
        sLPTemp As Integer,
        sLPTot As Integer,
        sKPTemp As Integer,
        sKPTot As Integer,
        sDodgeBonus As Integer,
        sPerceptionBonus As Integer,
        sHitBonus As Integer,
        sAttack1Bonus As Integer,
        sDmg1Stat As Stat,
        sDmg1Bonus As Integer,
        sDmg1DieCount As Integer,
        sDMG1DieSides As Integer,
        sAttack2Bonus As Integer,
        sDmg2Stat As Stat,
        sDmg2Bonus As Integer,
        sDmg2DieCount As Integer,
        sDmg2DieSides As Integer,
        sRoll1Bonus As Integer,
        sRoll1DieCount As Integer,
        sRoll1DieSides As Integer,
        sRoll2Bonus As Integer,
        sRoll2DieCount As Integer,
        sRoll2DieSides As Integer,
        sArmorRT As Integer,
        sArmorRR As Integer,
        sArmorMisc As Integer,
        sAPCurrent As Integer,
        sAPTotal As Integer,
        sAPNormalGain As Integer,
        sAPStraightGain As Integer,
        sInventory As List(Of InventoryItem),
        sAbilities As List(Of AbilityItem))
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
        Inventory = sInventory
        Abilities = sAbilities
    End Sub

    Public Sub New()

    End Sub

End Class
