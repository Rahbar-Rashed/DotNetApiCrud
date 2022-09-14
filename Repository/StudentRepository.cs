using CoreProject.IRepository;
using CoreProject.ServiceDTO;
using CoreProject.Helper;
using System.Linq;

namespace CoreProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly  AppDbContext _contextR;
        
        public StudentRepository(AppDbContext context)
        {
            _contextR = context;
        }

        public async Task<MessageHelper> AddStudent(StudentDTO obj)
        {
            try
            {
                var details = new Models.Student()
                {
                    StudentName = obj.StudentName,
                    StudentEmail = obj.StudentEmail,
                    StudentAddress = obj.StudentAddress,
                    IsActive = obj.IsActive,
                    LastServerAction = DateTime.Now,
                    ActionTime = obj.ActionTime
                };
                await _contextR.students.AddAsync(details);
                await _contextR.SaveChangesAsync();
                return new MessageHelper() { Message = "Data created successfully", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> EditStudent(StudentDTO obj)
        {
            try
            {
                var data = _contextR.students.Where(x=> x.StudentId == obj.StudentId).FirstOrDefault();
                if (data != null)
                {
                    data.StudentName = obj.StudentName;
                    data.StudentEmail = obj.StudentEmail;
                    data.StudentAddress = obj.StudentAddress;   
                    data.IsActive = obj.IsActive;
                    data.LastServerAction = DateTime.Now;
                    data.ActionTime = obj.ActionTime;
                }

                _contextR.students.Update(data);
                await _contextR.SaveChangesAsync();

                return new MessageHelper() { Message = "Data Edited Successfully", StatusCode = 200 };

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentDTO> GetStudentById(long StudentId)
        {
            try
            {
               var result =  await Task.FromResult((from std in _contextR.students
                                       where std.StudentId == StudentId
                                       select new StudentDTO
                                       {
                                           StudentId = std.StudentId,
                                           StudentName = std.StudentName,
                                           StudentEmail = std.StudentEmail,
                                           StudentAddress = std.StudentAddress,
                                           IsActive = std.IsActive,
                                           LastServerAction = std.LastServerAction,
                                           ActionTime = std.ActionTime
                                       }
                                       ).FirstOrDefault());
             return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
