# 🚀 Playwright E2E Automation Framework (C#)

Automated E2E and API testing framework for web apps build with **C#**, **Playwright** and **NUnit**.

---

## 📌 Tech Stack

* C#
* Playwright (.NET)
* NUnit
* Allure Report
* GitHub Actions (CI/CD)
* Serilog (logging)

---

## 🧱 Project Structure

```plaintext
PlaywrightE2ETest
│
├── Config/           # Environment configuration
├── Fixtures/         # BaseTest, setup/teardown
├── .github/          # CI pipeline
├── logs/             # Test logs
├── Pages/            # Page Object Model (UI logic)
├── screenshots/      # Created if test is failed
├── Tests/            # Test scenarios (UI + API)
└── Utils/            # Helpers (JSON, config, logger)
```

---

## ✅ Features

✔ Page Object Model (POM)
✔ Data-driven testing (JSON)
✔ Parallel test execution
✔ Screenshot on test failure
✔ Retry mechanism for flaky tests
✔ Allure reporting
✔ Logging (Serilog)
✔ CI/CD pipeline (GitHub Actions)
✔ API + UI testing in one project
✔ Environment configuration (DEV / STAGE / PROD)

---

## 🧪 Test Scenarios

### 🔐 Login

* valid login
* invalid password
* empty credentials
* locked user

### 🛒 Cart

* add product to cart
* open cart

### 🌐 API

* GET users request
* response validation

---

## ▶️ How to Run the Project

### 1. Clone repository

```bash
git clone <https://github.com/nikolahodasova/playwright-E2E-test>
cd PlaywrightE2ETest
```

---

### 2. Install dependencies

```bash
dotnet restore
```

---

### 3. Install Playwright browsers

```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

---

### 4. Run tests

```bash
dotnet test
```

---

## 📊 Allure Report

After running tests:

```bash
allure serve allure-results
```

---

## 🧪 Run tests by tag

```bash
dotnet test --filter "Category=Smoke"
```

---

## 🔁 CI/CD

Tests are automatically executed via **GitHub Actions** on push to `main` branch and pull requests. Allure reports are generated and uploaded as artifacts. 


# 🎭 Playwright E2E Test Automation Framework

## 🎯 Project Goal
This project demonstrates:
* **Real-world QA automation framework design** using Playwright.
* **Best practices** used in the industry (Page Object Model, Clean Code).
* **Readiness** for a Junior QA Automation role.

---

## 👩‍💻 Author
**[Nikola Hodásová]**
**QA Automation Engineer (Junior), QA Automation Tester (Junior)**

---

## 📂 Test Data (JSON)
Test data is stored and managed in:
```bash
TestData/LoginData.json
```
