﻿using bookstore.types;

namespace bookstore.interfaces
{
    public interface IBookstoreService
    {
        void TestWithException();

        string TestWithExceptionHandler();

        string Test();

        DatabaseStatus TestDatabaseConnection();

        GetAllBooksResponse GetAllBooks();

        GetBookDetailsResponse GetBookDetails(GetBookDetailsRequest request);

        StoreBookResponse StoreBook(StoreBookRequest request);
    }
}