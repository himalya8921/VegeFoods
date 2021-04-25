
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
function validateBilling() {
    isValid = true;
    emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
    numberRegex = /^[0-9]*$/

    if ($("#automation-first_name").val().trim() == "") {
        $("#FirstName_ErrorMessage").text("FirstName is required");
        isValid = false;
    }


    if ($("#automation-first_name").val().trim() != "" && $("#automation-first_name").val().trim().length < 6) {
        $("#FirstName_ErrorMessage").text("First Name is Invalid");
        isValid = false;
    }


    if ($("#automation-last_name").val().trim() == "") {
        $("#LastName_ErrorMessage").text("LastName is required");
        isValid = false;
    }


    if ($("#automation-last_name").val().trim() != "" && $("#automation-last_name").val().trim().length < 6) {
        $("#LastName_ErrorMessage").text("Last Name is Invalid");
        isValid = false;
    }



    if ($("#automation-state").val().trim() == "") {
        $("#State_ErrorMessage").text("State is required");
        isValid = false;
    }

    if ($("#automation-state").val().trim() != "" && $("#automation-state").val().trim().length < 6) {
        $("#State_ErrorMessage").text("State is Invalid");
        isValid = false;
    }

    if ($("#automation-address").val().trim() == "") {
        $("#StreetAddress_ErrorMessage").text("StreetAddress is required");
        isValid = false;
    }

    if ($("#automation-address").val().trim() != "" && $("#automation-address").val().trim().length < 6) {
        $("#StreetAddress_ErrorMessage").text("Address is Invalid");
        isValid = false;
    }

    if ($("#automation-city").val().trim() == "") {
        $("#Town_ErrorMessage").text("Town is required");
        isValid = false;
    }


    if ($("#automation-city").val().trim() != "" && $("#automation-city").val().trim().length < 6) {
        $("#Town_ErrorMessage").text("City is Invalid");
        isValid = false;
    }

    if ($("#automation-postcode").val().trim() == "") {
        $("#PostCode_ErrorMessage").text("PostCode is required");
        isValid = false;
    }
   
    if ($("#automation-postcode").val().trim() != "" && !numberRegex.test($("#automation-postcode").val().trim())) {
        console.log("user name ot validd");
        $("#PostCode_ErrorMessage").text("PostCode is Invalid");
        isValid = false;
    }


    if ($("#automation-phone").val().trim() == "") {
        $("#Phone_ErrorMessage").text("Phone is required");
        isValid = false;
    }

    if ($("#automation-phone").val().trim() != "" && !numberRegex.test($("#automation-phone").val().trim())) {
        $("#Phone_ErrorMessage").text("Phone Number is Invalid");
        isValid = false;
    }


    if ($("#automation-email").val().trim() == "") {
        $("#EmailAddress_ErrorMessage").text("EmailAddress is required");
        isValid = false;
    }

    if ($("#automation-email").val().trim() != "" && !emailRegex.test($("#automation-email").val().trim())) {
        console.log("user name ot validd");
        $("#UserName_ErrorMessage").text("username is Invalid");
        isValid = false;
    }

    
    return isValid;
}


function ValidateBillingForm() {
    console.log("---------button--------------");


    if (validateBilling() == true) {
        console.log("---------imside--------------");
        $("#BillingForm").submit();
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


