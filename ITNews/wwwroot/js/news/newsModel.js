var NewsModel = function (id, authorName, name, content, description, section, tags, authorId, comments, createdDate) {
    var self = this;
    self.id = id;
    self.authorName = authorName;
    self.authorId = authorId;
    self.name = name;
    self.content = content;
    self.description = description;
    self.sectionId = section;
    self.tags = tags ? tags : [];
    self.comments = comments;
    self.createdDate = createdDate;
    self.url = frontPath + '/news/News?id=' + id;
}