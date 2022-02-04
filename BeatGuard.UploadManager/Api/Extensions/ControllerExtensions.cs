using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BeatGuard.UploadManager.Api.Extensions
{
    public static class ControllerExtensions
    {
        /*public JsonResult EncryptedJsonResult(JsonResult json)
        {
            return Json(EncryptionHelper.EncryptPacket((JObject) json.Value));
        }*/

        public static JsonResult JSendSuccess(this Controller controller)
        {
            return controller.JSendSuccess(null);
            //var response = new JObject();
            //response["status"] = "success";
            //response["data"] = null;
            //return Json(response);
        }

        public static JsonResult JSendSuccess(this Controller controller, object data)
        {
            var response = new JObject();
            response["status"] = "success";
            response["data"] = data != null ? JObject.FromObject(data) : null;
            return controller.Json(response);
        }

        public static JsonResult JSendFail(this Controller controller, IEnumerable<ValidationFailure> errors)
        {
            return controller.JSendFail(errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage));
        }

        public static JsonResult JSendFail(this Controller controller, object data)
        {
            var response = new JObject();
            response["status"] = "fail";
            response["data"] = data != null ? JObject.FromObject(data) : null;
            return controller.Json(response);
        }

        public static JsonResult JSendError(this Controller controller, string message)
        {
            var response = new JObject();
            response["status"] = "error";
            response["message"] = message;
            return controller.Json(response);
        }

        public static JsonResult JSendError(this Controller controller, string message, int code)
        {
            var response = new JObject();
            response["status"] = "error";
            response["message"] = message;
            response["code"] = code;
            return controller.Json(response);
        }

        public static JsonResult JSendError(this Controller controller, string message, object data)
        {
            var response = new JObject();
            response["status"] = "error";
            response["message"] = message;
            if (data != null)
            {
                response["data"] = JObject.FromObject(data);
            }

            return controller.Json(response);
        }

        public static JsonResult JSendError(this Controller controller, string message, int code, object data)
        {
            var response = new JObject();
            response["status"] = "error";
            response["message"] = message;
            response["code"] = code;
            response["data"] = JObject.FromObject(data);
            return controller.Json(response);
        }
    }
}
