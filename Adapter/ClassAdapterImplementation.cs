using System;
namespace ClassAdapter
{
	public class CityFromExternalSystem
	{
		public string Name;
		public string NickName;
		public int Inhabitants;

		public CityFromExternalSystem(string name, string nickName, int inhabitants)
		{
			Name = name;
			NickName = nickName;
			Inhabitants = inhabitants;
		}
	}

	/// <summary>
	/// Adaptee
	/// </summary>
	public class ExternalSystem
	{
		public CityFromExternalSystem GetCity()
		{
			return new CityFromExternalSystem("Lagos", "LGA", 20000000);
		}
    }

	public class City
	{
		public string Fullname;
        public long Inhabitants;

        public City(string fullname, long inhabitants)
        {
            Fullname = fullname;
            Inhabitants = inhabitants;
        }
    }

	/// <summary>
	/// Target
	/// </summary>
	public interface ICityAdapter
	{
		City GetCity();
	}

	/// <summary>
	/// Adapter
	/// </summary>
    public class CityAdapter : ExternalSystem, ICityAdapter
    {
		public ExternalSystem ExternalSystem { get; private set; } = new();

        public new City GetCity()
        {
			var cityFromExternalSystem = base.GetCity();
			return new City($"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
        }
    }

}

