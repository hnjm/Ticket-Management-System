﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using AutoMapper;
using TicketManagementSystem.Web.Areas.Api.Models;

namespace TicketManagementSystem.Web.Areas.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IMapper MapperInstance => AutoMapperConfig.CreateMapper();

        protected IHttpActionResult NoContent() => StatusCode(HttpStatusCode.NoContent);

        protected IHttpActionResult OkOrNoContent<T>(IEnumerable<T> enumerable)
        {
            if (enumerable.Any())
                return Ok(enumerable);

            return NoContent();
        }

        protected IHttpActionResult OkOrNotFound<T>(T obj)
        {
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        protected HttpResponseMessage BadRequestWithErrors(ModelStateDictionary modelState)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, modelState.ToEnumerableString());
        }
    }
}