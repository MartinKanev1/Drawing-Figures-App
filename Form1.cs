using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net.WebSockets;
using Newtonsoft.Json.Linq;
using System.Windows.Input;

namespace tryoutsmth
{
    public partial class Form1 : Form
    {

        private readonly List<Figure> _figures = new List<Figure>();
        private Pen _pen = new Pen(Color.Black, 5);
        private Figure _currentFigure;
        private bool _isDrawing;
        private Point _startPoint;
        private Point _endPoint;
        private Color _outlineColor = Color.Black;
        private Color _fillColor = Color.Empty;
        private bool _readyToFill;
        private Figure _selectedFigure;
        private bool _isMoving = false;
        private bool _deleteMode = false;
        private Stack<List<Figure>> _undoStack = new Stack<List<Figure>>();
        private Stack<List<Figure>> _redoStack = new Stack<List<Figure>>();
        private bool _AreSelectedTypeOfFigures = false;
        public Figure[] SelectedTypeOfFigures;
        private FigureType _typedrawing;





        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
            DoubleBuffered = true;
        }


        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Edit");


            ToolStripMenuItem undoMenuItem = new ToolStripMenuItem("Undo");
            undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoMenuItem.Click += UndoMenuItem_Click;


            ToolStripMenuItem redoMenuItem = new ToolStripMenuItem("Redo");
            redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoMenuItem.Click += RedoMenuItem_Click;

            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save");
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Click += SaveMenuItem_Click;



            ToolStripMenuItem importMenuItem = new ToolStripMenuItem("Import");
            importMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            importMenuItem.Click += ImportMenuItem_Click;

            editMenu.DropDownItems.Add(undoMenuItem);
            editMenu.DropDownItems.Add(redoMenuItem);
            editMenu.DropDownItems.Add(saveMenuItem);
            editMenu.DropDownItems.Add(importMenuItem);

            ///////////////////////////////////////////////////////
            ToolStripMenuItem selectMenuItem = new ToolStripMenuItem("Select");
            editMenu.DropDownItems.Add(selectMenuItem);


            ToolStripDropDownButton selectDropDown = new ToolStripDropDownButton("Select by");
            selectMenuItem.DropDownItems.Add(selectDropDown);


            ToolStripDropDownItem selectFilledDropDownItem = new ToolStripMenuItem("Filled Figures");
            selectFilledDropDownItem.Click += SelectFilledDropDownItem_Click;
            selectDropDown.DropDownItems.Add(selectFilledDropDownItem);

            ToolStripDropDownItem selectUnfilledDropDownItem = new ToolStripMenuItem("Unfilled Figures");
            selectUnfilledDropDownItem.Click += SelectUnfilledDropDownItem_Click;
            selectDropDown.DropDownItems.Add(selectUnfilledDropDownItem);

            ToolStripDropDownItem selectALL = new ToolStripMenuItem("All");
            selectALL.Click += SelectALL_Click;
            selectDropDown.DropDownItems.Add(selectALL);

            ToolStripDropDownItem selectByTypeDropDownItem = new ToolStripMenuItem("Type");
            selectByTypeDropDownItem.DropDownItemClicked += SelectByTypeDropDownItem_DropDownItemClicked;


            ToolStripMenuItem rectangleMenuItem = new ToolStripMenuItem("Rectangle");
            rectangleMenuItem.Tag = typeof(Rectangle);
            selectByTypeDropDownItem.DropDownItems.Add(rectangleMenuItem);

            ToolStripMenuItem ellipseMenuItem = new ToolStripMenuItem("Ellipse");
            ellipseMenuItem.Tag = typeof(Ellipse);
            selectByTypeDropDownItem.DropDownItems.Add(ellipseMenuItem);

            ToolStripMenuItem squareMenuItem = new ToolStripMenuItem("Square");
            squareMenuItem.Tag = typeof(Square);
            selectByTypeDropDownItem.DropDownItems.Add(squareMenuItem);


            selectDropDown.DropDownItems.Add(selectByTypeDropDownItem);

            ///////////////////////////////////
            menuStrip.Items.Add(editMenu);
            Controls.Add(menuStrip);

            menuStrip.Focus();

        }

        private void SelectALL_Click(object? sender, EventArgs e)
        {
            var allFigures = _figures.ToArray();
            PerformAnAction(allFigures);
        }


        private void SelectByTypeDropDownItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Type selectedType = (Type)e.ClickedItem.Tag;

            var selectedFigures = _figures.Where(figure => figure.GetType() == selectedType).ToArray();
            PerformAnAction(selectedFigures);
        }

        private void SelectFilledDropDownItem_Click(object sender, EventArgs e)
        {
            var filledFigures = _figures.Where(figure => figure.IsFilled).ToArray();
            PerformAnAction(filledFigures);
        }

        private void SelectUnfilledDropDownItem_Click(object sender, EventArgs e)
        {
            var unfilledFigures = _figures.Where(figure => !figure.IsFilled).ToArray();
            PerformAnAction(unfilledFigures);
        }

        private void PerformAnAction(Figure[] array)
        {

            _AreSelectedTypeOfFigures = true;
            SelectedTypeOfFigures = array;



        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image (*.png)|*.png|JSON files(*.json)| *.json";
            saveFileDialog.Title = "Save Drawing";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                if (saveFileDialog.FilterIndex == 1)
                {

                    SaveAsImage(saveFileDialog.FileName);
                }
                else if (saveFileDialog.FilterIndex == 2)
                {

                    SaveToFile(saveFileDialog.FileName);
                }
            }
        }





        private void ImportMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Drawing File (*.draw)|*.draw|JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Import Drawing";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportFile(openFileDialog.FileName);
            }
        }

        private void ImportFile(string filePath)
        {
            try
            {
                
                string jsonString = File.ReadAllText(filePath);

                
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                };
                var importedFigures = JsonConvert.DeserializeObject<List<Figure>>(jsonString, settings);

                _figures.Clear();
                _figures.AddRange(importedFigures);
                Invalidate();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing drawing: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveAsImage(string filePath)
        {
           
            Bitmap bmp = new Bitmap(Width, Height);

            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                
                foreach (var figure in _figures)
                {
                    
                    figure.Draw(g);
                    figure.Fill(g, _fillColor);
                }
            }

            
            bmp.Save(filePath, ImageFormat.Png);

            
            bmp.Dispose();
        }



        private void SaveToFile(string filePath)
        {
            
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            
            string jsonString = JsonConvert.SerializeObject(_figures, settings);

            
            File.WriteAllText(filePath, jsonString);
        }


        
        private void TrackStateChange()
        {
            var currentState = new List<Figure>();
            foreach (var figure in _figures)
            {

                Figure copiedFigure = figure.Clone();



                currentState.Add(copiedFigure);
            }


            _undoStack.Push(currentState);
            _redoStack.Clear();
        }

        
        private void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var previousState = _undoStack.Pop();
                if (previousState != null && previousState.Count > 0)
                {
                    _redoStack.Push(new List<Figure>(_figures));
                    _figures.Clear();
                    _figures.AddRange(previousState);
                }

                Invalidate();
            }
        }
        private void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var nextState = _redoStack.Pop();
                if (nextState != null && nextState.Count > 0)
                {
                    _undoStack.Push(new List<Figure>(_figures));
                    _figures.Clear();
                    _figures.AddRange(nextState);
                }

                Invalidate();
            }
        }
        

        



        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }


        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        
        private void btn_color_Click(object sender, EventArgs e)

        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _outlineColor = colorDialog.Color;
            }
        }

        public enum FigureType
        {
            Rectangle,
            Ellipse,
            Square
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            _isDrawing = true;
            _isMoving &= !_isMoving;
            _readyToFill = false;
            _deleteMode = false;
            _typedrawing = FigureType.Rectangle;
            
        }

        private void btn_fil_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _fillColor = colorDialog.Color;
                _readyToFill = true;
                _isDrawing = false;
                _isMoving &= !_isMoving;
                _deleteMode = false;

                TrackStateChange();


                if (_AreSelectedTypeOfFigures)
                {
                    foreach (var figure in SelectedTypeOfFigures)
                    {
                        figure.FillColor = _fillColor;

                        figure.IsFilled = true;
                    }
                    _AreSelectedTypeOfFigures = false;
                }


                Invalidate();

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in _figures)
            {

                if (figure.IsFilled && figure.FillColor != Color.Empty)

                {
                    figure.Fill(e.Graphics, figure.FillColor);
                }
                figure.Draw(e.Graphics);

            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                foreach (var figure in _figures)
                {
                    if (figure.Contains(e.Location))
                    {
                        _currentFigure = figure;
                        break;
                    }
                }
                //_readyToFill = true;


                
            }
            _startPoint = e.Location;
            switch (_typedrawing)
            {

                case  FigureType.Rectangle: 

                    _currentFigure = new Rectangle(_startPoint.X, _startPoint.Y, 0, 0, _outlineColor);

                    break;

                case FigureType.Ellipse: 
                    _currentFigure = new Ellipse(_startPoint.X, _startPoint.Y, 0, 0, _outlineColor);
                    break;

                case FigureType.Square: 
                    _endPoint = e.Location;
                    int squareSize = Math.Max(Math.Abs(_endPoint.X - _startPoint.X), Math.Abs(_endPoint.Y - _startPoint.Y));
                    int squareX = Math.Min(_startPoint.X, _endPoint.X);
                    int squareY = Math.Min(_startPoint.Y, _endPoint.Y);
                    _currentFigure = new Square(squareX, squareY, squareSize, _outlineColor);
                    break;

            }









            
            if (e.Button == MouseButtons.Left && _isMoving)
            {

                if (_selectedFigure == null)
                {
                    _figures.Reverse();
                    foreach (var figure in _figures)
                    {

                        if (figure.Contains(e.Location))
                        {
                            _selectedFigure = figure;
                            break;
                        }
                    }
                    _figures.Reverse();
                }
            }

           

            if (e.Button == MouseButtons.Left && _readyToFill == true)
            {
                Figure topmostFigure = null;
                foreach (var figure in _figures)
                {
                    if (figure.Contains(e.Location))
                    {
                        
                        topmostFigure = figure;
                    }
                }

                
                if (topmostFigure != null)
                {
                    topmostFigure.IsFilled = true;
                    topmostFigure.FillColor = _fillColor;
                    TrackStateChange();
                    Invalidate();
                }
            }


            ////////////////////////////////////////
            if (e.Button == MouseButtons.Left && _deleteMode == true)
            {

                _startPoint = e.Location;

                for (int i = _figures.Count - 1; i >= 0; i--)
                {
                    if (_figures[i].Contains(_startPoint))
                    {

                        

                        _figures.RemoveAt(i);

                        TrackStateChange();
                        Invalidate();
                        return;
                    }
                }

            }


            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                foreach (var figure in _figures)
                {
                    if (figure.Contains(e.Location))
                    {

                        double area = figure.CalculateArea();


                        MessageBox.Show($"Area of the figure: {area.ToString("F2")}", "Figure Area", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        break;
                    }
                }
            }



        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            TrackStateChange();
            if (_currentFigure != null && _isDrawing)
            {

                _currentFigure.SetDimensions(_startPoint, e.Location);
                
                if (_readyToFill)
                {
                    _currentFigure.FillColor = _fillColor;
                    _currentFigure.IsFilled = true;
                    /////////////////////////
                }
                _figures.Add(_currentFigure);
                _currentFigure = null;
                _startPoint = Point.Empty;
                Invalidate();


            }
            
            if (_isMoving)
            {
                _selectedFigure = null;
            }
            


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _currentFigure?.SetDimensions(_startPoint, e.Location);

            }

            if (_isMoving && _selectedFigure != null)
            {
                int deltaX = e.X - _startPoint.X;
                int deltaY = e.Y - _startPoint.Y;

                _selectedFigure.X += deltaX;
                _selectedFigure.Y += deltaY;
                _startPoint = e.Location;


                Invalidate();
            }

        }

        private void btn_move_Click(object sender, EventArgs e)
        {

            _isMoving = !_isMoving;
            _isDrawing = false;
            _deleteMode = false;
            _readyToFill = false;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {

            _isMoving &= !_isMoving;
            _isDrawing = false;
            _readyToFill = false;
            _deleteMode = true;
            
            TrackStateChange();
            if (_AreSelectedTypeOfFigures)
            {
                foreach (var figure in SelectedTypeOfFigures)
                {

                    _figures.Remove(figure);
                }

            }
            
            Invalidate();

        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            _isDrawing = true;
            _isMoving &= !_isMoving;
            _readyToFill = false;
            _deleteMode = false;
            _typedrawing = FigureType.Square;
            
        }

        private void btn_Ellipse_Click(object sender, EventArgs e)
        {
            _isDrawing = true;
            _isMoving &= !_isMoving;
            _readyToFill = false;
            _deleteMode = false;
            _typedrawing = FigureType.Ellipse;
            
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (var figure in _figures)
            {
                if (figure.Contains(e.Location))
                {

                    using (ResizeForm resizeForm = new ResizeForm())
                    {

                        if (resizeForm.ShowDialog() == DialogResult.OK)
                        {
                            

                            int newWidth = resizeForm.NewWidth;
                            int newHeight = resizeForm.NewHeight;

                            figure.Width = newWidth;
                            figure.Height = newHeight;
                            TrackStateChange();
                            Invalidate();
                            
                            break;
                        }   

                    }
                }
            }
        }



       


    }
}