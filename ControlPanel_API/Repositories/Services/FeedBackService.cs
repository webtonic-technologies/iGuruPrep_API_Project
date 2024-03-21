using ControlPanel_API.DBContext;
using ControlPanel_API.DTOs;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlPanel_API.Repositories.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly AppDbContext _context;
        public FeedBackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddFeedBack(Feedback request)
        {
            try
            {
                var newFeedback = new Feedback
                {
                    CreatedDate = DateTime.Now,
                    FeedbackDesc = request.FeedbackDesc,
                    FeedbackID = request.FeedbackID,
                    FeedbackTypeID = request.FeedbackTypeID,
                    ParentfeedbackID = request.ParentfeedbackID,
                    Rating = request.Rating,
                    Status = request.Status,
                    SyllabusID = request.SyllabusID,
                    UserID = request.UserID
                };

                _context.tblUserFeedback.Add(newFeedback);
                _context.SaveChanges();

                return "Feedback added successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> AddSyllabus (Syllabus request)
        {
            try
            {
                var newSyllabus = new Syllabus
                {
                   CreatedOn = DateTime.Now,
                   BoardID = request.BoardID,
                   ClassId = request.ClassId,
                   CourseId = request.CourseId,
                   CreatedBy = request.CreatedBy,
                   Description = request.Description,
                   ModifiedBy = request.ModifiedBy,
                   ModifiedOn = request.ModifiedOn,
                   SyllabusId = request.SyllabusId,
                   Status = request.Status,
                   SyllabusName = request.SyllabusName,
                   YearID = request.YearID
                   
                };

                _context.tblSyllabus.Add(newSyllabus);
                _context.SaveChanges();

                return "Syllabus added successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetAllFeedbackResponse>> GetAllFeedBackList(GetAllFeedbackRequest request)
        {
            try
            {
                var list = new List<GetAllFeedbackResponse>();

                var data = _context.tblSyllabus.Where(x => x.ClassId.ToString() == request.ClassName || x.CourseId.ToString() == request.CourseName ||
                x.BoardID.ToString() == request.Boardname).ToList();


                foreach (var feedback in data)
                {
                    if (_context.tblUserFeedback.Where(x => x.SyllabusID == feedback.SyllabusId).FirstOrDefault() != null)
                    {
                        var data1 = _context.tblUserFeedback.Where(x => x.SyllabusID == feedback.SyllabusId).FirstOrDefault();
                        list.Add(new GetAllFeedbackResponse
                        {
                            Rating = data1.Rating,
                            Date = data1.CreatedDate,
                            FeedBackDesc = data1.FeedbackDesc,
                            Board = _context.tblBoard.Where(x=>x.BoardId==feedback.BoardID).Select(x=>x.BoardName).FirstOrDefault(),
                            Class = _context.tblClass.Where(x=>x.ClassId == feedback.ClassId).Select(x=>x.ClassName).FirstOrDefault(),
                            Course = _context.tblCourse.Where(x => x.CourseId == feedback.CourseId).Select(x => x.CourseName).FirstOrDefault(),
                        });
                    }
                }

                if (list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllFeedbackResponse>();
            }
        }
    }
}
