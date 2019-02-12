

$(document).ajaxSend(function (event, xhr) {
    var token = sessionStorage.getItem(tokenKey);
    xhr.setRequestHeader("Authorization", "Bearer " + token);
});

$(document).ajaxError(function (event, data) {
    if (data.status == 401) {
        window.location.href = frontPath + '/Authorize/Login';
    }
    if (data.status == 403) {
        showErrorAlert("Access denied")
    }
});
/*
window.addEventListener('storage', function (e) {
    debugger;
    if (e.storageArea === sessionStorage) {
        
        alert('change');
    }
    // else, event is caused by an update to localStorage, ignore it
});*/

var showSuccessAlert = function (text, timout) {
    //'<div class="alert alert-success">< strong > Success!</strong > Indicates a successful or positive action.</div >'
    text = text ? text : '';
    timout = timout ? timout : 2000
    var alert = $('<div></div>')
        .addClass('alert alert-success alert-dismissible fade show')
        .attr('role', 'alert')
        .append('<strong>Success! </strong>' + text)
        .append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>')
        //.append('<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Success! </strong>' + text)
        .appendTo('#alertContainer');
    setTimeout(function () {
        alert.remove();
    }, timout)
}/*
 '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>'
 */

var showErrorAlert = function (text, timout) {
    //'<div class="alert alert-success">< strong > Success!</strong > Indicates a successful or positive action.</div >'
    text = text ? text : '';
    timout = timout ? timout : 2000
    var alert = $('<div></div>')
        .addClass('alert alert-danger alert-dismissible fade show')
        .attr('role', 'alert')
        .append('<strong>Success! </strong>' + text)
        .append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>')
        //.append('<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Danger! </strong>' + text)
        .appendTo('#alertContainer');
    setTimeout(function () {
        alert.remove();
    }, timout)
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};