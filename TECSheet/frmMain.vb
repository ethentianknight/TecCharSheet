'The Ethentian Chronicles Digital Character Sheet
'Mark Davis and Daniel Holloway, 2014
'Very alpha.

Imports System.Runtime.InteropServices

Public Class frmMain

    Sub UpdateAll() '<-- simpler way to do this for all math-based text boxes?
        If txtSTR.Text = "" Then
            txtSTR.Text = 0
            'Move insertion point to front here.
        End If
        Try
            Dim dexDodgeBonus As Integer
            Dim lckDodgeBonus As Integer
            Dim mndPerceptionBonus As Integer
            If CInt(txtMND.Text) > 0 Then
                mndPerceptionBonus = CInt(((txtMND.Text) / 5) - 0.499) * 2
            Else
                mndPerceptionBonus = CInt(((txtMND.Text) / 5) + 0.499) * 2
            End If
            If CInt(txtDex.Text) > 0 Then
                dexDodgeBonus = CInt(((txtDex.Text) / 5) - 0.499) * 3
            Else
                dexDodgeBonus = CInt(((txtDex.Text) / 5) + 0.499) * 3
            End If

            If CInt(txtLCK.Text) > 0 Then
                lckDodgeBonus = CInt(((txtLCK.Text) / 5) - 0.499)
            Else
                lckDodgeBonus = CInt(((txtLCK.Text) / 5) + 0.499)
            End If
            txtDodgeDEX.Text = CInt(dexDodgeBonus + lckDodgeBonus)
            txtDodgeTot.Text = (CInt(txtDodgeDEX.Text) + CInt(txtDodgeBonus.Text))
            txtDodgeRT.Text = CInt(txtDodgeTot.Text) + CInt(txtArmorRT.Text)
            txtPerceptionMND.Text = CInt(txtMND.Text) + CInt(mndPerceptionBonus)
            txtPerceptionTot.Text = CInt(txtPerceptionMND.Text) + CInt(txtPerceptionBonus.Text)
            txtHitDex.Text = CInt(txtDex.Text)
            txtHitTot.Text = CInt(txtDex.Text) + CInt(txtHitBonus.Text)
            txtAttack1Hit.Text = CInt(txtHitTot.Text)
            txtAttack1Tot.Text = CInt(txtAttack1Hit.Text) + CInt(txtAttack1Bonus.Text)
            txtAttack2Hit.Text = CInt(txtHitTot.Text)
            txtAttack2Tot.Text = CInt(txtAttack2Hit.Text) + CInt(txtAttack2Bonus.Text)
            If cmbDmg1Stat.SelectedIndex = 1 Then
                txtDmg1Tot.Text = CInt(txtDmg1Bonus.Text) + CInt(txtSTR.Text)
            Else
                txtDmg1Tot.Text = CInt(txtDmg1Bonus.Text) + CInt(txtDex.Text)
            End If
            If cmbDmg2Stat.SelectedIndex = 1 Then
                txtDmg2Tot.Text = CInt(txtDmg2Bonus.Text) + CInt(txtSTR.Text)
            Else
                txtDmg2Tot.Text = CInt(txtDmg2Bonus.Text) + CInt(txtDex.Text)
            End If
            txtRoll1Tot.Text = CInt(txtRoll1Bonus.Text)
            txtRoll2Tot.Text = CInt(txtRoll2Bonus.Text)
        Catch ex As Exception
            MsgBox("Something went wrong while updating. Try again.")
        End Try
    End Sub

    Function Roll20(ByVal rollBonus As Integer) As Integer()
        UpdateAll()
        Dim critRange As Integer = 1
        Dim fumbleRange As Integer = 1
        If CInt(txtLCK.Text) > 0 Then
            critRange = CInt(((txtLCK.Text) / 5) - 0.499) + 1
        Else
            fumbleRange = CInt(((txtLCK.Text) / 5) + 0.499) * (-1) + 1
        End If
        Dim ReturnNum, CritStat, InitRoll As Integer
        InitRoll = (CInt(Int((20 * Rnd()) + 1)))
        ReturnNum = InitRoll + rollBonus
        If InitRoll = 0 + fumbleRange Then
            CritStat = 0
        ElseIf InitRoll = 21 - critRange Then
            CritStat = 2
        Else
            CritStat = 1
        End If
        Return {CInt(ReturnNum), CInt(CritStat)}
    End Function

    Function RollDNum(ByVal rollBonus As Integer, dieSides As Integer, dieCount As Integer) As Integer
        UpdateAll()
        Dim ReturnNum As Integer = 0
        If dieCount > 0 Then
            While dieCount > 0
                ReturnNum += (CInt(Int((dieSides * Rnd()) + 1)))
                dieCount -= 1
            End While
        End If
        Return ReturnNum
    End Function

    Private Sub Tog_CheckedChanged(sender As Object, e As EventArgs) Handles txtSTR.TextChanged,
                txtDex.TextChanged,
                txtMND.TextChanged,
                txtLCK.TextChanged,
                txtDodgeBonus.TextChanged,
                txtHitBonus.TextChanged,
                txtPerceptionBonus.TextChanged,
                txtAttack1Bonus.TextChanged,
                txtDmg1Bonus.TextChanged,
                txtDmg1DieCount.TextChanged,
                txtDMG1DieSides.TextChanged,
                cmbDmg1Stat.SelectedIndexChanged,
                txtAttack2Bonus.TextChanged,
                txtDmg2Bonus.TextChanged,
                txtDmg2DieCount.TextChanged,
                txtDmg2DieSides.TextChanged,
                cmbDmg2Stat.SelectedIndexChanged,
                txtRoll1Bonus.TextChanged,
                txtRoll1DieCount.TextChanged,
                txtRoll1DieSides.TextChanged,
                txtRoll2Bonus.TextChanged,
                txtRoll2DieCount.TextChanged,
                txtRoll2DieSides.TextChanged

        'Dim rb As TextBox = CType(sender, TextBox), con As Control = CType(rb.Tag, Control) --This code causes problems now that there are fewer check boxes.
        'con.Enabled = rb.Enabled
        UpdateAll() 'Causes instant errors on startup due to non-loaded form.
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbNameEnabled.Tag = txtName
        btnRollSTR.Tag = txtSTR
        btnRollDEX.Tag = txtDex
        btnRollMND.Tag = txtMND
        btnRollLCK.Tag = txtMND
        btnRollDodge.Tag = txtDodgeTot
        btnRollPerception.Tag = txtPerceptionTot
        btnRollHit.Tag = txtHitTot
        btnAttack1Roll.Tag = txtAttack1Tot
        btnAttack2Roll.Tag = txtAttack2Tot
        btnDmg1Roll.Tag = {txtDmg1Bonus, txtDMG1DieSides, txtDmg1DieCount}
        btnDmg2Roll.Tag = {txtDmg2Bonus, txtDmg2DieSides, txtDmg2DieCount}

        SendMessage(Me.txtName.Handle, &H1501, 0, "Name")
        SendMessage(Me.txtInventoryCount.Handle, &H1501, 0, "#")
        SendMessage(Me.txtInventoryName.Handle, &H1501, 0, "Name")
        SendMessage(Me.txtInventoryWeight.Handle, &H1501, 0, "Weight")
        SendMessage(Me.txtAbilityStack.Handle, &H1501, 0, "#")
        SendMessage(Me.txtAbilityName.Handle, &H1501, 0, "Name")
        SendMessage(Me.txtAbilityCost.Handle, &H1501, 0, "Cst")
        SendMessage(Me.txtAbilityCostStack.Handle, &H1501, 0, "Stk")

    End Sub

    Private Sub btnRoll_Click(sender As Object, e As EventArgs) Handles btnRollSTR.Click,
        btnRollDEX.Click,
        btnRollMND.Click,
        btnRollLCK.Click,
        btnRollDodge.Click,
        btnRollPerception.Click,
        btnRollHit.Click,
        btnAttack1Roll.Click,
        btnAttack2Roll.Click,
        btnDmg1Roll.Click,
        btnDmg2Roll.Click
        Dim tb As TextBox = CType(CType(sender, Button).Tag, TextBox)       '<-- Causes problems on damage rolls
        Dim output() = Roll20(CInt(tb.Text))
        Dim roll As Integer = output(0)
        Dim fumble As Integer = output(1)
        txtOutput.Text = roll
        If fumble = 0 Then
            txtOutput.BackColor = Color.Black
        ElseIf fumble = 2 Then
            txtOutput.BackColor = Color.Yellow
        Else
            txtOutput.BackColor = Color.WhiteSmoke
        End If


    End Sub

    Private Sub btnRollDEX_Click(sender As Object, e As EventArgs) Handles btnRollDEX.Click
        Dim output() = Roll20(CInt(txtDex.Text))
        Dim roll As Integer = output(0)
        Dim fumble As Integer = output(1)
        txtOutput.Text = roll
        If fumble = 0 Then
            txtOutput.BackColor = Color.Black
        ElseIf fumble = 2 Then
            txtOutput.BackColor = Color.Yellow
        Else
            txtOutput.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub btnDmgRoll_Click(sender As Object, e As EventArgs) Handles btnDmg1Roll.Click,
        btnDmg2Roll.Click
        Dim vals As TextBox() = CType(sender, TextBox())
        txtOutput.Text = RollDNum(vals(0).Text, vals(1).Text, vals(2).Text)
        txtOutput.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstInventory.Items.Add(txtInventoryCount.Text & vbTab & txtInventoryName.Text & vbTab & txtInventoryWeight.Text)
        lstInventory.SelectedIndex = lstInventory.Items.Count - 1
    End Sub

    Private Sub btnInventorySubtract_Click(sender As Object, e As EventArgs) Handles btnInventorySubtract.Click
        Dim selectedItem As Integer = lstInventory.SelectedIndex
        Try
            lstInventory.Items.RemoveAt(selectedItem)
            lstInventory.SelectedIndex = selectedItem - 1
            If lstInventory.SelectedIndex < 0 Then
                Try
                    lstInventory.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox("Please select an Item to remove!")
        End Try
    End Sub

    Private Sub btnInventoryUpdate_Click(sender As Object, e As EventArgs) Handles btnInventoryUpdate.Click
        Dim selectedItem As Integer = lstInventory.SelectedIndex
        Try
            lstInventory.Items.RemoveAt(selectedItem)
            lstInventory.Items.Insert(selectedItem, txtInventoryCount.Text & vbTab & txtInventoryName.Text & vbTab & txtInventoryWeight.Text)
            lstInventory.SelectedIndex = selectedItem
        Catch ex As Exception
            MsgBox("Please select an item to update!")
        End Try

    End Sub

    Private Sub btnAbilityAdd_Click(sender As Object, e As EventArgs) Handles btnAbilityAdd.Click
        Dim abilityList() As String
        Dim addAbility() As String
        addAbility = {txtAbilityStack.Text, txtAbilityName.Text, txtAbilityCost.Text, txtAbilityCostStack.Text}
        lstAbilities.Items.Add(CStr(addAbility(0) & vbTab & addAbility(1) & vbTab & vbTab & addAbility(2) & "/" & addAbility(3)))
        lstAbilities.SelectedIndex = lstAbilities.Items.Count - 1
    End Sub

    Private Sub btnAbilitySubtract_Click(sender As Object, e As EventArgs) Handles btnAbilitySubtract.Click
        Dim selectedItem As Integer = lstAbilities.SelectedIndex
        Try
            lstAbilities.Items.RemoveAt(selectedItem)
            lstAbilities.SelectedIndex = selectedItem - 1
            If lstAbilities.SelectedIndex < 0 Then
                Try
                    lstAbilities.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox("Please select an ability to remove!")
        End Try


    End Sub

    Private Sub btnAbilityUpdate_Click(sender As Object, e As EventArgs) Handles btnAbilityUpdate.Click
        Dim selectedItem As Integer = lstAbilities.SelectedIndex
        Try
            lstAbilities.Items.RemoveAt(selectedItem)
            lstAbilities.Items.Insert(selectedItem, txtAbilityStack.Text & vbTab & txtAbilityName.Text & vbTab & txtAbilityCost.Text & "/" & txtAbilityCostStack.Text)
            lstAbilities.SelectedIndex = selectedItem
        Catch ex As Exception
            MsgBox("Please select an ability to update!")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim inventory(lstInventory.Items.Count) As String
        If lstInventory.Items.Count > 0 Then
            Dim i As Integer = 0
            While i < (lstInventory.Items.Count)
                inventory(i) = lstInventory.Items(i)
                i += 1
            End While
        End If

        Dim abilities(lstAbilities.Items.Count) As String
        If lstAbilities.Items.Count > 0 Then
            Dim j As Integer = 0
            While j < (lstAbilities.Items.Count)
                abilities(j) = lstAbilities.Items(j)
                j += 1
            End While
        End If

        Dim player() As String =
            {
                txtName.Text,
                txtSTR.Text,
                txtDex.Text,
                txtMND.Text,
                txtLCK.Text,
                txtHPTemp.Text,
                txtHPTot.Text,
                txtMPTemp.Text,
                txtMPTot.Text,
                txtPPTemp.Text,
                txtPPTot.Text,
                txtLPTemp.Text,
                txtLPTot.Text,
                txtKPTemp.Text,
                txtKPTot.Text,
                txtDodgeBonus.Text,
                txtPerceptionBonus.Text,
                txtHitBonus.Text,
                txtAttack1Bonus.Text,
                cmbDmg1Stat.SelectedIndex,
                txtDmg1Bonus.Text,
                txtDmg1DieCount.Text,
                txtDMG1DieSides.Text,
                txtAttack2Bonus.Text,
                cmbDmg2Stat.SelectedIndex,
                txtDmg2Bonus.Text,
                txtDmg2DieCount.Text,
                txtDmg2DieSides.Text,
                txtRoll1Bonus.Text,
                txtRoll1DieCount.Text,
                txtRoll1DieSides.Text,
                txtRoll2Bonus.Text,
                txtRoll2DieCount.Text,
                txtRoll2DieSides.Text,
                txtArmorRT.Text,
                txtArmorRR.Text,
                txtArmorMisc.Text,
                txtAPCurrent.Text,
                txtAPTotal.Text,
                txtAPNormalGain.Text,
                txtAPStraightGain.Text
            }
        Dim playerFile As String = Application.StartupPath & "\" & txtName.Text & ".txt"
        IO.File.WriteAllLines(playerFile, player)
        Dim invFile As String = Application.StartupPath & "\" & txtName.Text & "Inventory.txt"
        IO.File.WriteAllLines(invFile, inventory)
        Dim abilFile As String = Application.StartupPath & "\" & txtName.Text & "Abilities.txt"
        IO.File.WriteAllLines(abilFile, abilities)
        UpdateAll()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim playerFile As String = Application.StartupPath & "\" & txtName.Text & ".txt"
        Try
            Dim player() As String = IO.File.ReadAllLines(playerFile)
            txtName.Text = player(0)
            txtSTR.Text = player(1)
            txtDex.Text = player(2)
            txtMND.Text = player(3)
            txtLCK.Text = player(4)
            txtHPTemp.Text = player(5)
            txtHPTot.Text = player(6)
            txtMPTemp.Text = player(7)
            txtMPTot.Text = player(8)
            txtPPTemp.Text = player(9)
            txtPPTot.Text = player(10)
            txtLPTemp.Text = player(11)
            txtLPTot.Text = player(12)
            txtKPTemp.Text = player(13)
            txtKPTot.Text = player(14)
            txtDodgeBonus.Text = player(15)
            txtPerceptionBonus.Text = player(16)
            txtHitBonus.Text = player(17)
            txtAttack1Bonus.Text = player(18)
            cmbDmg1Stat.SelectedIndex = player(19)
            txtDmg1Bonus.Text = player(20)
            txtDmg1DieCount.Text = player(21)
            txtDMG1DieSides.Text = player(22)
            txtAttack2Bonus.Text = player(23)
            cmbDmg2Stat.SelectedIndex = player(24)
            txtDmg2Bonus.Text = player(25)
            txtDmg2DieCount.Text = player(26)
            txtDmg2DieSides.Text = player(27)
            txtRoll1Bonus.Text = player(28)
            txtRoll1DieCount.Text = player(29)
            txtRoll1DieSides.Text = player(30)
            txtRoll2Bonus.Text = player(31)
            txtRoll2DieCount.Text = player(32)
            txtRoll2DieSides.Text = player(33)
            txtArmorRT.Text = player(34)
            txtArmorRR.Text = player(35)
            txtArmorMisc.Text = player(36)
            txtAPCurrent.Text = player(37)
            txtAPTotal.Text = player(38)
            txtAPNormalGain.Text = player(39)
            txtAPStraightGain.Text = player(40)
        Catch ex As Exception
            MsgBox("There's no save file with that player name!")
        End Try






        Dim invFile As String = Application.StartupPath & "\" & txtName.Text & "inventory.txt"
        Try
            Dim inventory() As String = IO.File.ReadAllLines(invFile)
            Dim k As Integer = 0
            lstInventory.Items.Clear()
            While k < inventory.Count
                lstInventory.Items.Add(inventory(k))
                k += 1
            End While
        Catch ex As Exception
            MsgBox("No inventory found!")
        End Try
        lstInventory.SelectedIndex = 0

        Dim abilFile As String = Application.StartupPath & "\" & txtName.Text & "abilities.txt"
        Try
            Dim abilities() As String = IO.File.ReadAllLines(abilFile)
            Dim l As Integer = 0
            lstAbilities.Items.Clear()
            While l < abilities.Count
                lstAbilities.Items.Add(abilities(l))
                l += 1
            End While
        Catch ex As Exception
            MsgBox("No abilities found!")
        End Try
        Try
            lstAbilities.SelectedIndex = 0
        Catch ex As Exception
        End Try

        UpdateAll()
    End Sub

    Private Sub btnAPCalc_Click(sender As Object, e As EventArgs) Handles btnAPCalc.Click
        Try
            If CInt(txtPartySize.Text) < 1 Then
                txtPartySize.Text = 1
            End If
            If CInt(txtAPTotal.Text) < 50 Then
                txtAPTotal.Text = 50
            End If
            If CInt(txtAPCurrent.Text) < 0 Then
                txtAPCurrent.Text = 0
            End If
            If CInt(txtAPCurrent.Text) > CInt(txtAPTotal.Text) Then
                txtAPTotal.Text = txtAPCurrent.Text
            End If
            Dim apGain As Integer = CInt(txtAPStraightGain.Text)
            If CInt(txtAPTotal.Text) < 50 Then
                txtAPTotal.Text = 50
            End If
            txtAPNormalGain.Text = CInt(txtAPNormalGain.Text) / CInt(txtPartySize.Text)
            apGain += CInt(txtAPNormalGain.Text) / CInt((CInt(txtAPTotal.Text) + 49) / 100)
            txtAPTotal.Text = CInt(txtAPTotal.Text) + apGain
            txtAPCurrent.Text = CInt(txtAPCurrent.Text) + apGain
            txtAPNormalGain.Text = 0
            txtAPStraightGain.Text = 0
        Catch ex As Exception
            MsgBox("Wrong AP Values!")
        End Try
    End Sub

    Private Sub btnCalcPoints_Click(sender As Object, e As EventArgs) Handles btnCalcPoints.Click
        UpdateAll()
        If txtHPTemp.Text(0) = "+" Or txtHPTemp.Text(0) = "-" Then
            txtHPTot.Text = CInt(txtHPTemp.Text) + CInt(txtHPTot.Text)
            txtHPTemp.Text = txtHPTot.Text
        End If
    End Sub

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function
End Class