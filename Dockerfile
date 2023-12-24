# Используем образ на основе Linux
FROM ubuntu:latest

# Устанавливаем необходимые пакеты, включая Wine и Xming
RUN dpkg --add-architecture i386 && \
    apt-get update && \
    apt-get install -y wine32 xvfb

# Создаем директорию для приложения
WORKDIR /app

# Копируем все файлы приложения в контейнер
COPY . .

# Устанавливаем переменную окружения для корректной работы с Wine
ENV WINEARCH=win32

# Инициализируем Wine и Xvfb
CMD Xvfb :1 -screen 0 1024x768x16 & wine AdminApp_YchetSotrudnikov.exe
