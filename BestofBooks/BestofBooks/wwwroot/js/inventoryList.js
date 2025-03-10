
function edit_row(no) {
    $("#edit_Id").val(no);

    var ISBN = document.getElementById("invListISBN-" + no).innerHTML;
    var Title = document.getElementById("invListTitle-" + no).innerHTML;
    var AuthorFirst = document.getElementById("invListAuthorFirst-" + no).innerHTML;
    var AuthorLast = document.getElementById("invListAuthorLast-" + no).innerHTML;
    var Genre = document.getElementById("invListGenre-" + no).innerHTML;
    var Location = document.getElementById("invListLocation-" + no).innerHTML;
    var Price = document.getElementById("invListPrice-" + no).innerHTML;
    var Qty = document.getElementById("invListQty-" + no).innerHTML;

    $("#edit_ISBN").val(ISBN);
    $("#edit_title").val(Title);
    $("#edit_authorFirst").val(AuthorFirst);
    $("#edit_authorLast").val(AuthorLast);
    $("#edit_genre").val(Genre);
    $("#edit_location").val(Location);
    $("#edit_price").val(Price);
    $("#edit_qty").val(Qty);

    $("#editDialog").modal("show");
}
