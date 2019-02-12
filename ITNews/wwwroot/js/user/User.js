var User = function (id, email, password, name, photo, roles) {
    var self = this;
    self.id = id;
    self.email = email;
    self.password = password;
    self.name = name;
    self.photo = photo;
    self.roles = roles;
    self.url = frontPath + '/?id=' + id;
}