
//$(window).on("load", function () {
//    console.log("Window is loaded");
//});

//$(window).on("unload", function () {
//    console.log("Window is unloaded");
//});

//$(window).resize( function () {
//    console.log("Window is resized");
//});




function validate() {


    console.log("IN the validate function");
    var isValid = false;
    var numberRegex = /^[0-9]*$/;
    var nameRegex = /^[a-zA-Z](\s?[a-zA-Z]){2,29}$/;
    // ^ -?\d +\.?\d * $


    $("#Age_ErrorMessage").text("");
    $("#Name_ErrorMessage").text("");
    $("#Desig_ErrorMessage").text("");
    $("#Salary_ErrorMessage").text("");
    $("#Gender_ErrorMessage").text("");

    console.log(isValid);



    if ($("#Id").val() == "") {
        $("#Id_ErrorMessage").text("Id is required");
        isValid = false;
    }

    if ($("#Name").val().trim() == "") {
        $("#Name_ErrorMessage").text("Name is required");
        isValid = false;
    }

    if ($("#Name").val().trim() != "" && !nameRegex.test($("#Name").val().trim())) {
        console.log("Name is invalid");
        $("#Name_ErrorMessage").text("Name is Invalid ");
        isValid = false;
    }


    if ($("#Age").val().trim() == "") {
        $("#Age_ErrorMessage").text("Age is required");
        isValid = false;
    }

    console.log("Result is " + numberRegex.test($("#Age").val().trim()));

    if ($("#Age").val().trim() != "" && !numberRegex.test($("#Age").val().trim())) {
        console.log("HEREEEEEEEE");
        $("#Age_ErrorMessage").text("Age is Invalid");
        isValid = false;
    }
    //else {
    //    $("#Age_ErrorMessage").text("");
    //    isValid = true;s
    //}

    if ($("#Designation").val() == "") {
        console.log("Entering in function");
        $("#Desig_ErrorMessage").text("Designation  is required");
        isValid = false;
    }


    if ($("#Salary").val().trim() == "") {
        $("#Salary_ErrorMessage").text("Salary is required");
        isValid = false;
    }


    if ($("#Salary").val().trim() == "") {
        $("#Salary_ErrorMessage").text("Salary is required");
        isValid = false;
    }

    if ($("#Salary").val().trim() != "" && !numberRegex.test($("#Salary").val().trim())) {
        console.log("HEREEEEEEEE");
        $("#Salary_ErrorMessage").text("salary is Invalid");
        isValid = false;
    }
    //else {
    //    $("#Salary_ErrorMessage").text("");
    //    isValid = true;
    //}




    return isValid;
}
function validateLogin() {
    isValid = true;
   
    if ($("#Username").val().trim() == "") {
        $("#UserName_ErrorMessage").text("UserName is required");
        isValid = false;
    }

    if ($("#Password").val().trim() == "") {
        $("#Password_ErrorMessage").text("Password is required");
        isValid = false;
    }

    if ($("#Password").val().trim() != "" && $("#Password").val().trim().length < 6) {
        console.log("Password invalid ");
        $("#Password_ErrorMessage").text("Password is Invalid");
        isValid = false;
    }
    return isValid;
}

function ValidateForm() {
    console.log("---------button--------------");


    if (validateLogin() == true) {
        console.log("---------imside--------------");
        $("#LoginForm").submit();
    }
}


function validateName() {

    /^[a-zA-Z][a-zA-Z]$/;
    if ($("#Name").val().trim() == "") {
        $("#Name_ErrorMessage").text("Name is required");
    }
    else {
        $("#Name_ErrorMessage").text("");
        isValid = true;
    }


}

function validateAge() {

    $("#Age_ErrorMessage").text("");
    var numberRegex = /^[0-9]*$/;

    if ($("#Age").val().trim() == "") {
        console.log("it is empty");
        $("#Age_ErrorMessage").text("Age is required");
    }
    //^[1-9][0-9]?$
    console.log("Result is " + numberRegex.test($("#Age").val().trim()));

    if ($("#Age").val().trim() != "" && !numberRegex.test($("#Age").val().trim())) {
        console.log("not empty but invalid");
        $("#Age_ErrorMessage").text("Age is Invalid");
        isValid = false;
    }
    else if ($("#Age").val().trim() != "" && numberRegex.test($("#Age").val().trim())) {
        console.log("All clear");
        $("#Age_ErrorMessage").text("");
    }


}


//$('#Username').keyup(function () {
//    validateName();
//})


$('#Age').keyup(function () {
    console.log("Key up on age called");
    validateAge();
})


