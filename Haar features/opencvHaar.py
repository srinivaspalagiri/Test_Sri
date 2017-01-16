import cv2
import numpy as np
face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')

eye_cascade = cv2.CascadeClassifier('haarcascade_eye.xml')
import sys
import  os

sys.path.append('/usr/local/lib/python2.7/site-packages')

#for the webcam
capture = cv2.VideoCapture(0)

while True:
    ret, img = capture.read()
    #converting to gray immediately
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    #for detecting multiScale
    faces = face_cascade.detectMultiScale(gray, 1.3, 5)
  

    for (x,y,w,h) in faces:
      
        #draw a rectangle
        cv2.rectangle(img,(x,y),(x+w,y+h),(255,0,0),2)
        #region of the image x - starting point & x+w is the ending point
        roi_gray = gray[y:y+h, x:x+w]
        roi_color = img[y:y+h, x:x+w]
        eyes = eye_cascade.detectMultiScale(roi_gray)
        for (ex,ey,ew,eh) in eyes:
            cv2.rectangle(roi_color,(ex, ey),(ex+ew, ey+eh),(0,225,0),2)
    cv2.imshow('img', img)
    k = cv2.waitKey(30) & 0xff
    if k == 27:
        break
capture.release()
cv2.destroyAllWindows()
