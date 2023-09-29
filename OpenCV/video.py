import cv2

face_cascsdes = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml') # подключаем распознавание лиц

# img = cv2.imread('face.jpg')

# img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) # конвертируем картинку в серый цвет

# faces = face_cascsdes.detectMultiScale(img_gray)

# for(x, y, w, h) in faces:
#     cv2.rectangle(img, (x, y), (x + w, y + h), (255, 0, 0), 2)

# cv2.imshow('Result', img)
# cv2.waitKey(0)


cap = cv2.VideoCapture(0) #соединяемся с веб камерой

while True:
    success, frame = cap.read() # считываем кадры с веб-камеры
    cv2.imshow('camera', frame)
    
    img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY) # конвертируем картинку в серый цвет
    faces = face_cascsdes.detectMultiScale(img_gray) # находим все лица

    for(x, y, w, h) in faces: # проходим по координатам найденных лиц
        cv2.rectangle(frame, (x, y), (x + w, y + h), (255, 0, 0), 2) # ресуем примоугольники по найденным координатам
        cv2.imshow('Result', frame) # показываем frame
    
    if cv2.waitKey(1) & 0xff == ord('q'): # выйти из бесконечного цикла кнопкой q
        break
