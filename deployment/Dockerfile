FROM ubuntu:22.04
ENV WINEDEBUG=fixme-all

RUN apt-get update && \
    apt-get install -y wget apt-transport-https software-properties-common ca-certificates && \
    dpkg --add-architecture i386 && \
    mkdir -pm755 /etc/apt/keyrings && \
    wget -O /etc/apt/keyrings/winehq-archive.key https://dl.winehq.org/wine-builds/winehq.key && \
    wget -NP /etc/apt/sources.list.d/ https://dl.winehq.org/wine-builds/ubuntu/dists/jammy/winehq-jammy.sources && \
    wget -O /usr/share/keyrings/xpra.asc https://xpra.org/xpra.asc && \
    wget -O /etc/apt/sources.list.d/xpra.sources https://xpra.org/repos/jammy/xpra.sources
    

RUN apt-get update && apt-get install -y --install-recommends winehq-stable=9.0.0.0~jammy-1

RUN apt-get install -y \
    python3-pip git \
    devscripts build-essential lintian debhelper pandoc \
    pkgconf libx11-dev libxtst-dev libxcomposite-dev libxdamage-dev libxres-dev \
    libxkbfile-dev python-all-dev pandoc libsystemd-dev \
    libgtk-3-dev python3-dev python3-cairo-dev python-gi-dev \
    xauth x11-xkb-utils \
    xvfb python3-gi-cairo \
    libturbojpeg-dev libwebp-dev python3-pil \
    libx264-dev libvpx-dev \
    python3-dbus python3-cryptography \
    python3-netifaces \
    openssh-client sshpass python3-paramiko \
    python3-setproctitle python3-xdg python3-pyinotify \
    libpam-dev xserver-xorg-dev xutils-dev xserver-xorg-video-dummy keyboard-configuration \
    python3-kerberos python3-gssapi \
    python3-gst-1.0 \
    gstreamer1.0-pulseaudio gstreamer1.0-alsa \
    gstreamer1.0-plugins-base gstreamer1.0-plugins-good \
    gstreamer1.0-plugins-ugly gstreamer1.0-plugins-bad gstreamer1.0-vaapi \
    liblz4-dev python3-lz4 \
    libbrotli-dev \
    libxxhash-dev \
    python3-coverage \
    x11-xserver-utils dbus-x11 

RUN pip3 install Cython

RUN git clone https://github.com/Xpra-org/xpra && \
    cd xpra && \
    python3 ./setup.py install --prefix=/usr --install-layout=deb 

RUN git clone https://github.com/Xpra-org/xpra-html5 && \
    cd xpra-html5 && \
    ./setup.py install
#RUN apt-get install -y xpra=5.0.5-r0-1 && \
#    apt-get clean

RUN useradd -ms /bin/bash xpra-test

RUN wget -P /mono https://dl.winehq.org/wine/wine-mono/9.0.0/wine-mono-9.0.0-x86.msi && \
    wine msiexec /i /mono/wine-mono-9.0.0-x86.msi && \
    wineserver -w && \
    chown -R xpra-test:xpra-test /mono

COPY ./WindowsFormsApp2.exe /home/xpra-test/program/WindowsFormsApp2.exe
COPY ./run.sh /home/xpra-test/run.sh
RUN chmod +x /home/xpra-test/run.sh && \
    chown -R xpra-test:xpra-test /home/xpra-test/program
    
USER xpra-test

RUN wine msiexec /i /mono/wine-mono-9.0.0-x86.msi && \
    wineserver -w && \
    rm -rf /mono/wine-mono-9.0.0-x86.msi
    
CMD ["/bin/bash", "/home/xpra-test/run.sh"]
