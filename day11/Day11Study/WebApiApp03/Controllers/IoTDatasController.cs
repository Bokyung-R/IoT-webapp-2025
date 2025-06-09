using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp03.Models;

namespace WebApiApp03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTDatasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IoTDatasController(AppDbContext context)
        {
            _context = context;
        }

        //// GET: api/IoT_Datas
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<iot_datas>>> GetIoTDatas()
        //{
        //    return await _context.iot_datas.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<iot_datas>>> GetIoTDatas(string serviceKey, string startDate, string endDate, string resultType)
        {
            // 실제 데이터포털(data.go.kr)에서 사용하는 방법
            // 1. 서비스키가 일치하는 요청만 수행
            if(string.IsNullOrWhiteSpace(serviceKey))
            {
                return BadRequest();
            }
            else
            {
                // 서버에서 키를 검색해서 검증된 키인지 확인하고 맞으면 진행
            }

            // 2. pageNo. numOfRows 파라미터가 있으면, 실제 데이터를 페이징해서 데이터를 돌려받음
            Debug.WriteLine(startDate, endDate);
            var result = await _context.iot_datas.FromSql($"SELECT * FROM iot_datas WHERE sensing_dt BETWEEN {startDate} AND {endDate}").ToListAsync();
            
            // 3. resultType이 xml 과 json에 따라 리턴하는 데이터형을 변경
            if (resultType == "xml")
            {
                // XML으로 형변환
            }
            else if(resultType == "jsons")
            {
                // JSON으로 형변환
            }
            return result;
        }

        // GET: api/IoT_Datas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<iot_datas>> GetIoTDatas(int id)
        {
            var IoT_Datas = await _context.iot_datas.FindAsync(id);

            if (IoT_Datas == null)
            {
                return NotFound();
            }

            return IoT_Datas;
        }

        //// PUT: api/IoT_Datas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIoTDatas(int id, iot_datas ioTDatas)
        //{
        //    if (id != ioTDatas.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ioTDatas).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IoT_DatasExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/IoT_Datas
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<iot_datas>> PostIoT_Datas(iot_datas IoTDatas)
        //{
        //    _context.iot_datas.Add(IoTDatas);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetIoT_Datas", new { id = IoTDatas.Id }, IoTDatas);
        //}

        //// DELETE: api/IoT_Datas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteIoTDatas(int id)
        //{
        //    var IoTDatas = await _context.iot_datas.FindAsync(id);
        //    if (IoTDatas == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.iot_datas.Remove(IoTDatas);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool IoTDatasExists(int id)
        //{
        //    return _context.iot_datas.Any(e => e.Id == id);
        //}
    }
}
