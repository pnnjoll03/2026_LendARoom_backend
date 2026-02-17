# 2026-LendARoom-backend

## Description
LendARoom Backend adalah sistem manajemen peminjaman ruangan berbasis API yang dibangun menggunakan ASP.NET Core. Proyek ini berfungsi untuk mengelola data master ruangan, menangani pengajuan peminjaman (booking), serta mencatat riwayat peminjaman secara otomatis.

## Features
* **CRUD Master Room**: Pengelolaan data ruangan lengkap dengan validasi.
* **Loan Request System**: Fitur pengajuan pinjaman ruangan untuk pengguna.
* **History Archiving**: Pencatatan otomatis setiap transaksi yang selesai atau ditolak ke tabel riwayat.
* **Soft Deletes**: Keamanan data menggunakan fitur penghapusan sementara.
* **Database Migration & Seeder**: Pengelolaan skema database dan data awal (dummy data).

## Tech Stack
* **Framework**: ASP.NET Core Web API
* **Language**: C#
* **Database**: SQL Server / MySQL (Entity Framework Core)
* **Validation**: DTO dengan DataAnnotations

## Installation
1. Pastikan .NET SDK sudah terinstal di perangkat Anda.
2. Clone repositori ini.
3. Jalankan perintah migrasi untuk menyiapkan tabel:
   `dotnet ef database update`
4. Jalankan aplikasi:
   `dotnet run`

## Usage
API akan berjalan di `http://localhost:5187`. Dokumentasi endpoint dapat diakses melalui Swagger UI di path `/swagger`.

## Environment Variables
Salin `.env.example` menjadi `.env` dan sesuaikan variabel berikut:
* `DB_CONNECTION_STRING`: String koneksi database Anda.

## License
MIT License

## Credits
**Author**: Tim LendARoom 2026