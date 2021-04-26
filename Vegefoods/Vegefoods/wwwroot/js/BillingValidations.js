
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
 

    if (validateBilling() == true) {
       
        $("#BillingForm").submit();
    }
}
