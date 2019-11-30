using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeWork27_9_19
{
	class Program
	{
		static void Main(string[] args)
		{
			Homework();
		}

		private static void Homework()
		{
			/*
			1.Объявить в консольном приложении класс Book с полями: название, стоимость, автор, год.
				Создать коллекцию элементов Book и заполнить тестовыми данными. 
				С помощью класса BinaryFormatter сохранить состояние приложения в двоичный файл.

			2.На основании задания 1 восстановить состояние приложения из двоичного файла.
			*/
			var books = new List<Book>
			{
				new Book
				{
					Name = "Novels",
					Author = "Pushkin",
					Price = 999,
					Year = 2017
				},
				new Book
				{
					Name = "Poems",
					Author = "Shakespeare",
					Price = 2500,
					Year = 2015
				},
			};

			var serializer = new BinaryFormatter();

			using (var stream = File.OpenWrite("1.bin"))
			{
				serializer.Serialize(stream, books);
			}

			using (var stream = File.OpenRead("1.bin"))
			{
				var result = serializer.Deserialize(stream) as List<Book>;
			}
		}
	}
}
