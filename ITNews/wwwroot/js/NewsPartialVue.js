var NewsPartialViewModel = function () {
    let self = this;
    self.newsVue = new Vue({
        el: '#newsPartial',
        data: {
            tagsArray: ['dom', 'um', 'hous', 'domik'],
            tagsSelected: []
        },
        computed: {
            
        },
        methods: {
            initialize: function () {
                autocomplete(document.getElementById("myInput"),
                    self.newsVue.tagsArray,
                    self.newsVue.tagsSelected,
                    self.newsVue.callBackForAutoComplete);
            },
            callBackForAutoComplete: function () {
                /*let isExist = viewModel.newsVue.tagsSelected.some(function (item) {
                    return $('#myInput').val() == item;
                });
                if (!isExist) {
                    viewModel.newsVue.tagsSelected.push($('#myInput').val());
                };
                $('#myInput').val('');
                */
            },
            tagsWithoutSelectedItems: function () {
                let arr = [];
                self.newsVue.tagsArray.forEach(function (item) {
                    let isExist = false;
                    self.newsVue.tagsSelected.forEach(function (selectedItem) {
                        if (selectedItem == item) {
                            isExist = true;
                        }
                    });
                    if (!isExist) {
                        arr.push(item);
                    };
                });
                return arr;
            }
        }
    });
}