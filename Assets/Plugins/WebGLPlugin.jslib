mergeInto(LibraryManager.library, {
  GetLocalStorageValue: function () {
    const userIdTokenized = localStorage.getItem("userIdTokenized");

    var bufferSize = lengthBytesUTF8(userIdTokenized) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(userIdTokenized, buffer, bufferSize);
    return buffer;
  }
});
