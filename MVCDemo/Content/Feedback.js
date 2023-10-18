$(document).ready(function () {
    Feedbacklist();
    GetDetails();
});
var saveFeedback = function () {
    debugger;
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var number = $("#txtNumber").val();
    var idanumber = $("#txtIDANumber").val();
    var address = $("#txtAddress").val();
    var email = $("#txtEmail").val();
    var grade = $("#txtGrade").val();

    var model =
    {
        Id:id,
        Name: name,
        Number: number,
        IDANumber: idanumber,
        Address: address,
        Email: email,
        Grade: grade
    };

    $.ajax({
        url: "/Feedback/SaveFeedback",
        method: "post",
        data: JSON.stringify(model),
        dataType: "json",
        contentType: "application/json;charset=utf-8",

        success: function (response) {
            alert(response.Message);
        },
        error: function (response) {
            alert(response.Message);
        }

    });

}

var Feedbacklist = function () {
    debugger;
    $.ajax({
        url: "/Feedback/ListFeedback",
        method: "post",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblFeedback tbody").empty();
            $.each(response.Message, function (index, elementvalue) {
                html += "<tr><td>" + elementvalue.Id +
                    "</td><td>" + elementvalue.Name +
                    "</td><td>" + elementvalue.Number +
                    "</td><td>" + elementvalue.IDANumber +
                    "</td><td>" + elementvalue.Address +
                    "</td><td>" + elementvalue.Email +
                    "</td><td>" + elementvalue.Grade +
                    "</td><td><input type='button' class='btn btn-secondary' value='Edit' onclick='EditFeedback(" + elementvalue.Id +
                    ")'><i class='bi bi-pencil-square'></i></button></td><td><input type='submit' class='btn btn-danger' value='Delete' onclick='DeleteFeedback(" + elementvalue.Id +
                    ")'/></td><td><input type='button' class='btn btn-success' value='Details' onclick='Details(" + elementvalue.Id + ")'/></td></tr>";
            });
            $("#tblFeedback tbody").append(html);
        }
    });
}

var DeleteFeedback = function (Id)
{
    var model = { Id: Id };
    $.ajax({
        url: "/Feedback/DeleteFeedback",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            alert(" Feedback deleted  successfully");
        }


    });

}

var EditFeedback  = function (Id) {
    var model = { Id: Id };
    $.ajax({

        url: "/Feedback/EditFeedback",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response)
        {
            $("#hdnId").val(response.model.Id);
            $("#txtName").val(response.model.Name);
            $("#txtNumber").val(response.model.Number);
            $("#txtIDANumber").val(response.model.IDANumber);
            $("#txtAddress").val(response.model.Address);
            $("#txtEmail").val(response.model.Email);
            $("#txtGrade").val(response.model.Grade);


        }
    })
}
var Details = function (Id) {
    window.location.href = "/Feedback/DetailIndex?Id=" + Id
}
var GetDetails = function (Id) {
    debugger;
    var id = $("#hdnId").val();
    model = {
        Id: id
    }
    $.ajax({

        url: "/Feedback/EditFeedback",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            html += "<tr><td>" + response.model.Id +
                "</td><td>" + response.model.Name +
                "</td><td>" + response.model.Number +
                "</td><td>" + response.model.IDANumber +
                "</td><td>" + response.model.Address +
                "</td><td>" + response.model.Email +
                "</td><td>" + response.model.Grade +
                "</tr></td>";


            $("#tblDetails").append(html);
        }
    });
}