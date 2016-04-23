
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices


''' <summary>
''' 任意のルートフォルダから下の階層のフォルダを選択できるようにしたもの
''' 参考URL：http://dobon.net/vb/bbs/log3-46/27833.html
''' </summary>

Public Class FolderDialog


    Public Overloads Shared Function Show(ByVal title As String) As String
        Return FolderDialog.BrowseForFolder(title, 576, Type.Missing)
    End Function


    Public Overloads Shared Function Show(ByVal title As String, ByVal root As Environment.SpecialFolder) As String
        Return FolderDialog.BrowseForFolder(title, 576, root)
    End Function


    Public Overloads Shared Function Show(ByVal title As String, ByVal root As String) As String
        Return FolderDialog.BrowseForFolder(title, 576, root)
    End Function


    Public Overloads Shared Function Show(ByVal title As String, ByVal options As Flags) As String
        Return FolderDialog.BrowseForFolder(title, CType(options,Integer), Type.Missing)
    End Function


    Public Overloads Shared Function Show(ByVal title As String, ByVal root As Environment.SpecialFolder, ByVal options As Flags) As String
        Return FolderDialog.BrowseForFolder(title, CType(options,Integer), CType(root,Integer))
    End Function


    Public Overloads Shared Function Show(ByVal title As String, ByVal root As String, ByVal options As Flags) As String
        Return FolderDialog.BrowseForFolder(title, CType(options,Integer), root)
    End Function


    Private Shared Function BrowseForFolder(ByVal title As String, ByVal options As Integer, ByVal root As Object) As String
        Dim returnPath As String = Nothing
        Dim hwnd As IntPtr = IntPtr.Zero
        If (Not (Form.ActiveForm) Is Nothing) Then
            hwnd = Form.ActiveForm.Handle
        End If
        
        Dim shell As Shell32.Shell = New Shell32.ShellClass
        Dim folder As Shell32.Folder = shell.BrowseForFolder(hwnd.ToInt32, title, options, root)
        If (Not (folder) Is Nothing) Then
            Dim items As Shell32.FolderItems = folder.Items
            If (Not (items) Is Nothing) Then
                Dim item As Shell32.FolderItem = Nothing
                item = items.Item(Type.Missing)
                If (Not (item) Is Nothing) Then
                    returnPath = item.Path
                    Marshal.ReleaseComObject(item)
                End If
                
                Marshal.ReleaseComObject(items)
            End If
            
            Marshal.ReleaseComObject(folder)
        End If
        
        Marshal.ReleaseComObject(shell)
        Return returnPath
    End Function


    <Flags()>  _
    Public Enum Flags
        
        ReturnOnlyFSDirs = 1
        
        DontGoBelowDomain = 2
        
        StatusText = 4
        
        RetrunFSAncestors = 8
        
        EditBox = 16
        
        Validate = 32
        
        NewDialgStyle = 64
        
        UseNewUI = 80
        
        BrowseIncludUrls = 128
        
        UAHint = 256
        
        NoNewFolderButton = 512
        
        NoTranslateTargets = 1024
        
        BrowseForComputer = 4096
        
        BrowseForPrinter = 8192
        
        BrowseIncludeFiles = 16384
        
        Shareable = 32768
    End Enum
End Class