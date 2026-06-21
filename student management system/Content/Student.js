/// <reference path="../scripts/jquery-3.7.0.min.js" />
alert("Student.js Loaded");

function SaveStudent() {

    alert("Function Called");

    var Id = $("#hdnID").val();
    var Name = $("#txtName").val();
    var Course = $("#txtCourse").val();
    var Fees = $("#txtFees").val();

    var model = {
        Id: Id,
        Name: Name,
        Course: Course,
        Fees: Fees
    };

    $.ajax({
        url: "/Student/Savestudent",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(JSON.stringify(response));
        
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
            console.log(xhr.responseText);
        
        }

    });
}
function UpdateStudent() {

    var Id = $("#hdnID").val();
    var Name = $("#txtName").val();
    var Course = $("#txtCourse").val();
    var Fees = $("#txtFees").val();

    var model = {
        Id: Id,
        Name: Name,
        Course: Course,
        Fees: Fees
    };

    $.ajax({
        url: "/Student/UpdateStudent",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            window.location.href = "/Student/List";
        },
        error: function (xhr, status, error) {
            alert("Update Error");
            console.log(xhr.responseText);
        }
    });
}


function DeleteStudent(id) {
    if (confirm("Are you sure you want to delete?")) {
        $.ajax({
            url: '/Student/DeleteStudent',
            type: 'POST',
            data: { id: id },
            success: function (response) {
                alert(response.Message);
                location.reload();
            },
            error: function () {
                alert("Delete Failed");
            }
        });
    }
}