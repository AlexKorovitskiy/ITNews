let Comment = function (id, content, createdDate, newsId, authorId, author) {
    let self = this;
    self.id = id;
    self.content = content;
    self.createdDate = new Date(createdDate).toLocaleString();
    self.newsId = newsId;
    self.authorId = authorId;
    self.author = author
        ? new User(author.Id, author.Email, undefined, author.Name, author.Photo)
        : undefined;
}