namespace Zulu.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        //creamos un metodo async
        //para poblar la base de datos

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //para checkear si hay paises
            await checkCountriesAsync();

        }

        private async Task checkCountriesAsync()
        {
            //el metodo any devuelve tru si hay un registro
            if(!_context.Countries.Any()) 
            {
                //ACA MARCAMOS
                _context.Countries.Add(new Shared.Entities.Country { Name = "PERU" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "COLOMBIA" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "MEXICO" });

                //ACA GUARDAMOS
                await _context.SaveChangesAsync();
            }
        }
    }
}
