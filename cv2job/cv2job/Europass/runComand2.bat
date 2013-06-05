@ECHO
java -jar C:\Users\Ricardo\Documents\GitHub\LI4\cv2job\cv2job\Europass\europass-soapws-client.jar -F C:\Users\Ricardo\Documents\GitHub\LI4\cv2job\cv2job\Europass\%1.xml -O C:\Users\Ricardo\Documents\GitHub\LI4\cv2job\cv2job\Europass\%1\ -L _pt_PT -T exml -M to-pdf-exml-cv
rename C:\Users\Ricardo\Documents\GitHub\LI4\cv2job\cv2job\Europass\%1\*.pdf %1.pdf