// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Used to set background color of current page navigation tab through aria controls
document.querySelectorAll('.navLink').forEach
    (link => {
        if (link.href === window.location.href) {
            link.setAttribute('aria-current', 'page')
        }
    })

Array.prototype.forEach.call(document.body.querySelectorAll("*[data-mask]"), applyDataMask);

function applyDataMask(field) {
    var mask = field.dataset.mask.split('');

    // For now, this just strips everything that's not a number
    function stripMask(maskedData) {
        function isDigit(char) {
            return /\d/.test(char);
        }
        return maskedData.split('').filter(isDigit);
    }

    // Replace `_` characters with characters from `data`
    function applyMask(data) {
        return mask.map(function (char) {
            if (char != '_') return char;
            if (data.length == 0) return char;
            return data.shift();
        }).join('')
    }

    function reapplyMask(data) {
        return applyMask(stripMask(data));
    }

    function changed() {
        var oldStart = field.selectionStart;
        var oldEnd = field.selectionEnd;

        field.value = reapplyMask(field.value);

        field.selectionStart = oldStart;
        field.selectionEnd = oldEnd;
    }

    field.addEventListener('click', changed)
    field.addEventListener('keyup', changed)
}

function showTable(table) {
    document.getElementById(table).style.visibility = "visible";
}

function showBtn(button) {
    document.getElementById(button).style.visibility = "visible";
}

/* Add event listener to Clear buttons */
// todo: remove this after relocated in local page js
//document.getElementById("ClearBtn").addEventListener("click", function () {
//    clearInput("textFilter");
//    resetSelect("searchOptions");
//})


function clearInput(input) {
    document.getElementById(input).value = "";
}

function resetSelect(selectElement) {
    document.getElementById(selectElement).selectedIndex = 0;
}


/*Print function has stopped working*/
/* Set Print Function */
function PrintPage(elementID) {
    var prtContent = document.getElementById(elementID);
    var WinPrint = window.open('', '', 'left=0, top=0, width=800, height=900, toolbar=0, scrollbars=0, status=0');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}

/* Update user rights from Admin screen */

function toggleViewOnly(cb, id) {
    let newValue = cb.checked;
    var postJson = {};
    var postUrl = "/api/user/updateViewOnlyRights";
    cb.enabled = false;

    postJson.BoBuser_id = id;
    postJson.is_ViewOnly = newValue;
    $.ajax(postUrl, {
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(postJson),
        success: function (data, status, xhr) {
            cb.enabled = true;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert("Error: " + errorMessage);
            cb.checked = !newValue;
            cb.enabled = true;
        }
    });
}

function toggleAddsEnabled(cb, id) {
    let newValue = cb.checked;
    var postJson = {};
    var postUrl = "/api/user/updateAddRights";
    cb.enabled = false;

    postJson.BoBuser_id = id;
    postJson.adds_enabled = newValue;
    $.ajax(postUrl, {
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(postJson),
        success: function (data, status, xhr) {
            cb.enabled = true;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert("Error: " + errorMessage);
            cb.checked = !newValue;
            cb.enabled = true;
        }
    });
}

function toggleEditsEnabled(cb, id) {
    let newValue = cb.checked;
    var postJson = {};
    var postUrl = "/api/user/updateEditRights";
    cb.enabled = false;

    postJson.BoBuser_id = id;
    postJson.edits_enabled = newValue;
    $.ajax(postUrl, {
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(postJson),
        success: function (data, status, xhr) {
            cb.enabled = true;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert("Error: " + errorMessage);
            cb.checked = !newValue;
            cb.enabled = true;
        }
    });
}

function toggleDeletesEnabled(cb, id) {
    let newValue = cb.checked;
    var postJson = {};
    var postUrl = "/api/user/updateDeleteRights";
    cb.enabled = false;

    postJson.BoBuser_id = id;
    postJson.deletes_enabled = newValue;
    $.ajax(postUrl, {
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(postJson),
        success: function (data, status, xhr) {
            cb.enabled = true;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert("Error: " + errorMessage);
            cb.checked = !newValue;
            cb.enabled = true;
        }
    });
}

function toggleIsAdmin(cb, id) {
    let newValue = cb.checked;
    var postJson = {};
    var postUrl = "/api/user/updateAdminRights";
    cb.enabled = false;

    postJson.BoBuser_id = id;
    postJson.is_Admin = newValue;
    $.ajax(postUrl, {
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(postJson),
        success: function (data, status, xhr) {
            cb.enabled = true;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert("Error: " + errorMessage);
            cb.checked = !newValue;
            cb.enabled = true;
        }
    });
}