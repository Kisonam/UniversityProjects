package com.example.bookstore;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class BookstoreApplication {

	public static void main(String[] args) {
		try {
			// Запуск тестів за допомогою Maven
			Process process = new ProcessBuilder()
					.command("mvn", "test")
					.inheritIO() // Перенаправляє консольний вивід до стандартного виводу
					.start();
			int result = process.waitFor(); // Чекаємо завершення процесу

			if (result != 0) {
				System.err.println("Тести не пройдені. Програма не буде запущена.");
				System.exit(1);
			}
		} catch (Exception e) {
			e.printStackTrace();
			System.err.println("Помилка при виконанні тестів.");
			System.exit(1);
		}

		// Якщо тести пройшли, запускаємо програму
		SpringApplication.run(BookstoreApplication.class, args);
	}

}
