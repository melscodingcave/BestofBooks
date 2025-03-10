// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Report Dropdown Author Button with Search- When the user clicks on the button,
toggle between hiding and showing the dropdown content, filter */
function dropdownState() {
    document.getElementById("authorDropdown").classList.toggle("show");
}

//this filter function is not working, not set up to read from DB
function filterFunction() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("authorInput");
    filter = input.value.toUpperCase();
    div = document.getElementById("authorDropdown");
    a = div.getElementsByTagName("a");
    for (i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }
}

function printMe() {
    PrintPage("printArea");
}

