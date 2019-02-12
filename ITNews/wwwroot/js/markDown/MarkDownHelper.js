function markDownShowMode(markDown) {
    //jQuery(markDown[0].nextSibling).find('button.btn-preview').click();
    jQuery(newsEntity.markDown[0].nextSibling).find('div.md-toolbar').hide();
    jQuery(markDown[0].nextSibling).find('button.btn-preview').triggerHandler('click');
}

function editMode(markDown) {
    jQuery(newsEntity.markDown[0].nextSibling).find('div.md-toolbar').show();
    jQuery(markDown[0].nextSibling).find('button.btn-edit').click();
}