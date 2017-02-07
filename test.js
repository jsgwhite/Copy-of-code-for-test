function Hello() {
    return 'hello';;
}

var fullname = 'John Doe';
var objects = {
    fullname: 'Bob John',
    getFullname: function () {
        return objects.fullname;
    }
};


// TESTS...

require('chai').should();
var assert = require("assert")

describe('Hello', function () {
    it('should return hello', function () {
        assert.equal('hello', Hello());
    });
});

describe('Ojects fullname', function () {
    it('should return Bob John', function () {
        assert.equal(objects.fullname, objects.getFullname());
    })
})
