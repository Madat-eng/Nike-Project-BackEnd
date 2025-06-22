//using DAL;
//using DAL.DTOs;

//namespace BAL
//{
//    public class PersonBusiness
//    {
//        public static DTOPerson GetPersonById(int personId)
//        {
//            try
//            {
//                var person = PersonData.GetPersonByID(personId);
//                if (person == null)
//                    throw new Exception($"Person with ID {personId} was not found.");
//                return person;
//            }
//            catch (Exception ex)
//            {
//                throw new ApplicationException($"Service error while fetching person by ID {personId}.", ex);
//            }
//        }

//        public static bool CreatePerson(DTOPerson person)
//        {
//            try
//            {
//                return PersonData.CreatePerson(person);
//            }
//            catch (Exception ex)
//            {
//                throw new ApplicationException("Service error while creating person.", ex);
//            }
//        }

//        public static bool UpdatePerson(DTOPerson person)
//        {
//            try
//            {
//                return PersonData.UpdatePerson(person);
//            }
//            catch (Exception ex)
//            {
//                throw new ApplicationException($"Service error while updating person with ID {person.PersonID}.", ex);
//            }
//        }

//        public static bool DeletePerson(int personId)
//        {
//            try
//            {
//                return PersonData.DeletePerson(personId);
//            }
//            catch (Exception ex)
//            {
//                throw new ApplicationException($"Service error while deleting person with ID {personId}.", ex);
//            }
//        }
//    }
//}