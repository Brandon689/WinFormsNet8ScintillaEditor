namespace WinFormsTilla;
using ScintillaNET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();


        // In your form or control
        Scintilla scintilla = new Scintilla();
        this.Controls.Add(scintilla);
        scintilla.Dock = DockStyle.Fill;
        SetupCSharpSyntaxHighlighting(scintilla);

        scintilla.SetProperty("fold", "1");
        scintilla.SetProperty("fold.compact", "1");

        // Configure a margin to display folding symbols
        scintilla.Margins[2].Type = MarginType.Symbol;
        scintilla.Margins[2].Mask = Marker.MaskFolders;
        scintilla.Margins[2].Sensitive = true;
        scintilla.Margins[2].Width = 20;

        // Set colors for all folding markers
        for (int i = 25; i <= 31; i++)
        {
            scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
            scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
        }

        // Configure folding markers with respective symbols
        scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
        scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
        scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
        scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
        scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
        scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
        scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

        // Enable automatic folding
        scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
    }


    void SetupCSharpSyntaxHighlighting(Scintilla scintilla)
    {
        // Configuring the default style with properties
        // we have common to every lexer style saves time.
        scintilla.StyleResetDefault();
        scintilla.Styles[Style.Default].Font = "Consolas";
        scintilla.Styles[Style.Default].Size = 10;
        scintilla.StyleClearAll();

        // Configure the CPP (C#) lexer styles
        scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
        scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
        scintilla.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
        scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
        scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
        scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
        scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        scintilla.LexerName = "cpp";

        // Set the keywords
        scintilla.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
        scintilla.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
    }


}
