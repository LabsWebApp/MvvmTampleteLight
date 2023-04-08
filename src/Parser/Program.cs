using System.Collections;
using System.Reflection;
using DataModels.Entities;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Crypto.Agreement.JPake;


var order = new Dictionary<string, (int, SupportsType)>();
var idPlace = 0;

var place = new Place();

foreach (var prop in place.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
{
    if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
        continue;

    Console.WriteLine($"{prop.Name} - номер столбца в файле:");
    if (int.TryParse(Console.ReadLine(), out var n))
    {
        if (prop.Name.ToLower() == "id") idPlace = n;
        Console.WriteLine($"{prop.Name} - номер столбца в файле:");
        // order.Add(prop.Name, n);
    }
}

Console.ReadKey();

var fileInfo = @"D:\Downloads\Вариант 6\Сессия 1\Город_import.xlsx";
using var stream = File.Open(fileInfo, FileMode.Open, FileAccess.Read);
XSSFWorkbook workbook = new XSSFWorkbook(stream);

// Access the worksheet
XSSFSheet worksheet = (XSSFSheet)workbook.GetSheet(workbook.GetSheetName(0));




foreach (var prop in place.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
{
    if(typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string)) 
        continue;
    
    Console.WriteLine($"{prop.Name} - номер столбца в файле:");
    if (int.TryParse(Console.ReadLine(), out var n))
    {
        if(prop.Name.ToLower() == "id") idPlace = n;
        Console.WriteLine($"{prop.Name} - номер столбца в файле:");
       // order.Add(prop.Name, n);
    }
}

//Console.ReadKey();

for (var i = 0; !string.IsNullOrEmpty(worksheet.GetRow(i).GetCell(idPlace).ToString()); i++)
{

}

//SupportsType GetPropType(PropertyInfo info) => info switch
//{
//    PropertyInfo.
//}


Console.WriteLine(worksheet.GetRow(0).GetCell(0));
Console.WriteLine(worksheet.GetRow(0).GetCell(1).CellType);
Console.WriteLine(worksheet.GetRow(0).GetCell(2));


Console.ReadLine();

enum SupportsType
{
    String,
    Password,
    Int,
    Double,
    DateTime,
    Image
}

class AnyParser<T> : IDisposable where T : class
{

    private readonly Stream _stream;

    private readonly XSSFSheet _worksheet;


    private readonly IList<Dictionary<PropertyInfo, object>> results;

    public AnyParser(string path)
    {
        _stream = File.Open(path, FileMode.Open, FileAccess.Read);

        XSSFWorkbook workbook = new XSSFWorkbook(_stream);
        // Access the worksheet
        _worksheet = (XSSFSheet)workbook.GetSheet(workbook.GetSheetName(0));

        var props  = typeof(T).GetProperties(BindingFlags.Public);
    }


    public void SetPropsOrder()
    {

    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
