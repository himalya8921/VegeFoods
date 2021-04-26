
function validateLogin() {
    isValid = true;
    emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/

    var useremail = $("#Username").val().trim();
    if (useremail == "") {
        $("#UserName_ErrorMessage").text("UserName is required");
        isValid = false;
    }

    if (useremail != "" && !emailRegex.test(useremail)) {
        console.log("user name ot validd");
        $("#UserName_ErrorMessage").text("username is Invalid");
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

    if (validateLogin() == true) {
        $("#LoginForm").submit();
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

function validateEmail() {
    isValid = true;
    emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/

    var useremail = $("#Username").val().trim();
    if (useremail == "") {
        $("#UserName_ErrorMessage").text("Email is required");
    }

    if (useremail != "" && !emailRegex.test(useremail)) {
        console.log("user name ot validd");
        $("#UserName_ErrorMessage").text("Email is Invalid");
    }
    else if (useremail != "" && emailRegex.test(useremail)) {
        console.log("All clear");
        $("#UserName_ErrorMessage").text("");
    }

}


$("#Username").keyup(function () {

    console.log("uffff touch kyu kiya")
    validateEmail();
})
