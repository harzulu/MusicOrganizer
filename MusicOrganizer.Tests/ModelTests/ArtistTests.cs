using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
    [TestClass]
    public class ArtistTest : IDisposable
    {

      public void Dispose()
      {
        Artist.ClearAll();
      }

      [TestMethod]
      public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
      {
        Artist newArtist = new Artist("Test Artist");
        Assert.AreEqual(typeof(Artist), newArtist.GetType());
      }

      
      [TestMethod]
      public void GetName_ReturnsName_String()
      {
        string name = "Test Artist";
        Artist newArtist = new Artist(name);
        string result = newArtist.Name;
        Assert.AreEqual(name, result);
      }

      [TestMethod]
      public void GetId_ReturnArtistId_int()
      {
        string name = "Test Artist";
        Artist newArtist = new Artist(name);
        int result = newArtist.Id;
        Assert.AreEqual(1, result);
      }

      [TestMethod]
      public void GetAll_ReturnAllArtistObjects_ArtistList()
      {
        string name = "Test Artist1";
        string name2 = "Test Artist2";
        Artist newArtist1 = new Artist(name);
        Artist newArtist2 = new Artist(name2);
        List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

        List<Artist> result = Artist.GetAll();

        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void Find_ReturnCorrectArtist_Artist()
      {
        string name = "Test Artist1";
        string name2 = "Test Artist2";
        Artist newArtist1 = new Artist(name);
        Artist newArtist2 = new Artist(name2);
        Artist artist = Artist.Find(2);

        Assert.AreEqual(newArtist2, artist);
      }

      [TestMethod]
      public void AddRecord_AssociatesRecordWithArtist_RecordList()
      {
        string record = "Test Record";
        Record newRecord = new Record(record);
        List<Record> newList = new List<Record> { newRecord };
        string name = "Test Artist";
        Artist newArtist = new Artist(name);
        newArtist.AddRecord(newRecord);
        
        List<Record> result = newArtist.Records;

        CollectionAssert.AreEqual(newList, result);
      }

    }
}