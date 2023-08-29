using Adapter;

Console.Title = "Adapter";

// Object Adapter
ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();

Console.WriteLine($"{city.Fullname}, {city.Inhabitants}");

// Class Adapter
ClassAdapter.ICityAdapter classAdapter = new ClassAdapter.CityAdapter();
var classAdapterCity = classAdapter.GetCity();

Console.WriteLine($"{classAdapterCity.Fullname}, {classAdapterCity.Inhabitants}");
Console.ReadKey();