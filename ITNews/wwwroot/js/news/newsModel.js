var NewsModel = function (id, authorName, name, content, description, section, tags) {
    var self = this;
    self.id = id;
    self.authorName = authorName,
    self.name = name;
    self.content = content;
    self.description = description;
    self.section = section;
    self.tags = tags;
    self.url = frontPath + '/news/News?id=' + id;
}