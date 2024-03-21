using ControlPanel_API.DBContext;
using ControlPanel_API.DTOs;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel_API.Repositories.Services
{
    public class StoryOfTheDayService : IStoryOfTheDayService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StoryOfTheDayService(AppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task AddNewStoryOfTheDay(StoryOfTheDayDTO storyOfTheDayDTO)
        {
            var storyOfTheDay = new StoryOfTheDay
            {
                Question = storyOfTheDayDTO.Question,
                BoardName = storyOfTheDayDTO.BoardName,
                ClassName = storyOfTheDayDTO.ClassName,
                PostTime = storyOfTheDayDTO.PostTime,
                DateAndTime = storyOfTheDayDTO.PostTime,
                Answer = storyOfTheDayDTO.Answer,
                AnswerRevealTime = new TimeSpan(0, storyOfTheDayDTO.AnswerRevealTime.Value.Hours, storyOfTheDayDTO.AnswerRevealTime.Value.Minutes, storyOfTheDayDTO.AnswerRevealTime.Value.Seconds, storyOfTheDayDTO.AnswerRevealTime.Value.Microseconds),
                Status = storyOfTheDayDTO.Status
            };

            if (storyOfTheDayDTO.UploadImage != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "StoryOfTheDay");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(storyOfTheDayDTO.UploadImage.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await storyOfTheDayDTO.UploadImage.CopyToAsync(fileStream);
                }
                storyOfTheDay.UploadImage = fileName;
            }
            else
            {
                storyOfTheDay.UploadImage = string.Empty;
            }

            await _context.tblSOTD.AddAsync(storyOfTheDay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStoryOfTheDay(UpdateStoryOfTheDayDTO storyOfTheDayDTO)
        {
            var storyOfTheDay = await _context.tblSOTD.FindAsync(storyOfTheDayDTO.QuestionId);

            if (storyOfTheDay == null)
                throw new Exception("Story of the day not found");

            storyOfTheDay.Question = storyOfTheDayDTO.Question;
            storyOfTheDay.BoardName = storyOfTheDayDTO.BoardName;
            storyOfTheDay.ClassName = storyOfTheDayDTO.ClassName;
            storyOfTheDay.PostTime = storyOfTheDayDTO.PostTime;
            storyOfTheDay.DateAndTime = storyOfTheDayDTO.PostTime;
            storyOfTheDay.Answer = storyOfTheDayDTO.Answer;
            storyOfTheDay.AnswerRevealTime = new TimeSpan(0, storyOfTheDayDTO.AnswerRevealTime.Value.Hours, storyOfTheDayDTO.AnswerRevealTime.Value.Minutes, storyOfTheDayDTO.AnswerRevealTime.Value.Seconds, storyOfTheDayDTO.AnswerRevealTime.Value.Microseconds);
            storyOfTheDay.Status = storyOfTheDayDTO.Status;

            _context.tblSOTD.Update(storyOfTheDay);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StoryOfTheDayDTO>> GetAllStoryOfTheDay()
        {
            var storyOfTheDays = await _context.tblSOTD.ToListAsync();
            return storyOfTheDays.Select(s => new StoryOfTheDayDTO
            {
                QuestionId = s.QuestionId,
                Question = s.Question,
                BoardName = s.BoardName,
                ClassName = s.ClassName,
                PostTime = s.PostTime,
                DateAndTime = s.DateAndTime,
                Answer = s.Answer,
                AnswerRevealTime = s.AnswerRevealTime,
                Status = s.Status
            });
        }

        public async Task<StoryOfTheDayDTO> GetStoryOfTheDayById(int id)
        {
            var storyOfTheDay = await _context.tblSOTD.FindAsync(id);

            if (storyOfTheDay == null)
                throw new Exception("Story of the day not found");

            return new StoryOfTheDayDTO
            {
                QuestionId = storyOfTheDay.QuestionId,
                Question = storyOfTheDay.Question,
                BoardName = storyOfTheDay.BoardName,
                ClassName = storyOfTheDay.ClassName,
                PostTime = storyOfTheDay.PostTime,
                DateAndTime = storyOfTheDay.DateAndTime,
                Answer = storyOfTheDay.Answer,
                AnswerRevealTime = storyOfTheDay.AnswerRevealTime,
                Status = storyOfTheDay.Status
            };
        }

        public async Task DeleteStoryOfTheDay(int id)
        {
            var storyOfTheDay = await _context.tblSOTD.FindAsync(id);

            if (storyOfTheDay == null)
                throw new Exception("Story of the day not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "StoryOfTheDay", storyOfTheDay.UploadImage);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.tblSOTD.Remove(storyOfTheDay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStoryOfTheDayFile(StoryOfTheDayIdAndFileDTO storyOfTheDayDTO)
        {
            var storyOfTheDay = await _context.tblSOTD.FindAsync(storyOfTheDayDTO.QuestionId);

            if (storyOfTheDay == null)
                throw new Exception("Story of the day not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "StoryOfTheDay", storyOfTheDay.UploadImage);
            if (File.Exists(filePath) && !string.IsNullOrWhiteSpace(storyOfTheDay.UploadImage))
            {
                File.Delete(filePath);
            }

            if (storyOfTheDayDTO.UploadImage != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "StoryOfTheDay");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(storyOfTheDayDTO.UploadImage.FileName);
                var newFilePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(newFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await storyOfTheDayDTO.UploadImage.CopyToAsync(fileStream);
                }
                storyOfTheDay.UploadImage = fileName;
            }

            _context.tblSOTD.Update(storyOfTheDay);
            await _context.SaveChangesAsync();
        }

        public async Task<byte[]> GetStoryOfTheDayFileById(int id)
        {
            var storyOfTheDay = await _context.tblSOTD.FindAsync(id);

            if (storyOfTheDay == null)
                throw new Exception("Story of the day not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "StoryOfTheDay", storyOfTheDay.UploadImage);

            if (!File.Exists(filePath))
                throw new Exception("File not found");

            return await File.ReadAllBytesAsync(filePath);
        }
    }
}