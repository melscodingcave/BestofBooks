function edit_row(id) {
    // Populate hidden ID field
    $("#edit_Id").val(id);

    // Read raw cell text — .textContent strips any inner HTML tags
    // (badge spans, dollar signs etc.) leaving just the visible text
    const isbn = document.getElementById("invListISBN-" + id).textContent.trim();
    const title = document.getElementById("invListTitle-" + id).textContent.trim();
    const genre = document.getElementById("invListGenre-" + id).textContent.trim();
    const location = document.getElementById("invListLocation-" + id).textContent.trim();

    // Price cell contains "$34.99" — strip the leading dollar sign
    const price = document.getElementById("invListPrice-" + id)
        .textContent.trim().replace('$', '');

    // Qty badge contains "In stock · 7" or "Low · 2" or "Out of stock"
    // Extract just the number from the end, defaulting to 0 if not found
    const qtyText = document.getElementById("invListQty-" + id).textContent.trim();
    const qtyMatch = qtyText.match(/\d+$/);
    const qty = qtyMatch ? qtyMatch[0] : '0';

    // Read author first/last from hidden spans — reliable for any name format
    const authorFirst = document.getElementById("invListAuthorFirst-" + id).textContent.trim();
    const authorLast = document.getElementById("invListAuthorLast-" + id).textContent.trim();

    // Populate modal fields
    $("#edit_ISBN").val(isbn);
    $("#edit_title").val(title);
    $("#edit_authorFirst").val(authorFirst);
    $("#edit_authorLast").val(authorLast);
    $("#edit_genre").val(genre);
    $("#edit_location").val(location);
    $("#edit_price").val(price);
    $("#edit_qty").val(qty);

    // Open the edit modal
    var modal = new bootstrap.Modal(document.getElementById('editDialog'));
    modal.show();
}