namespace Vued.App.ViewModels;

public class MediaCheckbox : BindableObject
{
    private bool _isChecked;

    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            _isChecked = value;
            OnPropertyChanged();
        }
    }
}