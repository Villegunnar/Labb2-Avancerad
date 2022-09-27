namespace Labb2_Avancerad.Models
{
    public interface IPersonalRepository 
    {


        //Read
        IEnumerable<Personal> GetAllPersonals { get; }

        //Read
        Personal GetPersonalById(int personalId);

        //Create
        Personal AddPersonal(Personal personal);


        //Update
        Personal UpdatePersonal(Personal personal);

        //Delete
        Personal DeletePersonal(int personalId);


    }
}
