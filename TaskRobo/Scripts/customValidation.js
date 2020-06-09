//This function should validate Task Titlte which should allow only alpha numerals
//and should also display error message in a <p> element with id as 'titleMsg'
function validateTitle(title, elementId) {

    $("#", elementId).html('Title should be alphanumeric');
}

//This function checks if taskContent is not empty and length is not more 50 characters
//and also displays error message in a <p> element with id as 'contentMsg'
function validateContent() {
  
}

//This function checks if taskStatus is not empty and length is not more 10 characters
//and also displays error message in a <p> element with id as 'statusMsg'
function validateStatus() {
    
}

//This function checks if Category is selected or not. Category is mandatory
//and also displays error message in a <p> element with id as 'categoryMsg'
// It should also prevents the form to submit, if category is not selected.
function validateForm() {
   
}

$(function () {
    console.log('adding form validation');

    $("form[name='task']").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            TaskTitle: "required",
            TaskStatus: "required",

            TaskContent: {
                required: true,
                minlength: 5
            }
        },
        // Specify validation error messages
        messages: {
            TaskTitle: "Please enter your firstname",
            TaskStatus: "Please enter your TaskStatus",
            TaskContent: {
                required: "Please provide a TaskContent",
                minlength: "Your TaskContent must be at least 5 characters long"
            },

        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

})