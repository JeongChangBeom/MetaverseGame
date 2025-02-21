# 🎮 Metaverse Game

스파르타 내일배움캠프에서 Unity 과제로 진행한 개인 프로젝트입니다. 간단하게 메타버스 환경을 구축하여 게임의 기본적인 요소들을 직접 구현해보면서 공부하기 위해 제작했습니다. 

## 개요 

* **제목** : Metarverse Game
* **개발 환경** : Unity 2022.3.17f1
* **인원** : 정창범 (1명)
* **개발 기간** : 2025.02.17 ~ 2025.02.20
* **주요 기능** : 캐릭터 이동, 2가지 미니 게임, 점수 시스템 및 리더보드, 캐릭터 커스터 Metaverse Game
스파르타 내일배움캠프에서 Unity 개인 과제로 진행한 개인 프로젝트

## 기능

**1. 캐릭터 이동**  
* WASD를 눌러 플레이어 캐릭터를 이동할 수 있습니다.
* 블렌드 트리를 활용하여 이동하는 방향에 따라 다른 Move 애니메이션이 나오며, 멈췄을 때도 바라보는 방향에 따라 다른 Idle 애니메이션이 나옵니다.

---

**2. 맵 설계 및 상호작용**
* 타일맵을 사용하여 간단하게 맵을 설계하고 일부 오브젝트와 상호작용할 수 있습니다.
* 상호작용할 수 있는 오브젝트를 바라보면 상호작용 할 때 눌러야 하는 키를 보여줍니다.
  
![image](https://github.com/user-attachments/assets/aeb6fb71-506a-418a-8f2f-e5654cc03a47)

---

**3. 미니 게임**
* GameBox 오브젝트와 상호작용하여 2가지 미니 게임을 골라 플레이할 수 있습니다.
    
  ![image](https://github.com/user-attachments/assets/b7149357-8d54-4f16-a270-6384d28442ba)

  * **[Stack]**  
  블럭을 높이 쌓는 게임입니다. 마우스 좌클릭을 눌러 블럭을 쌓을 수 있으며 블럭을 쌓지 못하는 곳에 블럭을 쌓으려고 시도하면 GameOver가 됩니다. GameOver가 되면 기록이 저장되며 다시 게임을 재개하거나 메타버스 맵으로 이동할 수 있습니다.
    
    ![image](https://github.com/user-attachments/assets/75d5de74-285e-428d-b206-9ea272f92931)  ![image](https://github.com/user-attachments/assets/457c0418-a413-4bf2-987f-7ce4952d9f26)  ![image](https://github.com/user-attachments/assets/f34f1576-29aa-44b9-95db-802a581c80d6)

  * **[Agnet Run]**  
  요원이 오른쪽으로 달려가면서 장애물을 피하는 게임입니다. 스페이스 바를 눌러 점프할 수 있으며, 더블 점프가 가능합니다. 발판에서 떨어지거나 가시를 밟으면 Game가 되고 기록이 저장됩니다. 이후 다시 게임을 재개하거나 메타버스 맵으로 이동할 수 있습니다.

    ![image](https://github.com/user-attachments/assets/2aef7b07-0c28-4763-8b9c-00b68d15d818)  ![image](https://github.com/user-attachments/assets/3694ebf6-74ef-42ca-a4c4-e18d0e459b06)

---

**4. 캐릭터 커스터마이징**
* 좌측 상단의 Custom 버튼을 눌러 커스터마이징을 진행할 수 있습니다.
* 캐릭터에게 장식(무기)를 장착시킬 수 있고, 색상을 변경할 수 있습니다.
* 우측에는 Preview가 보이며 우측 하단의 Save 버튼을 눌러 캐릭터에 적용시킬 수 있습니다.

  ![image](https://github.com/user-attachments/assets/27d70bb9-20aa-4cce-8498-8c927db06fb1)  ![image](https://github.com/user-attachments/assets/dd9ee6d4-b4eb-4918-a621-a07444c2339e)


---

**5. 리더보드**
* 각 미니게임의 최고 점수를 확인할 수 있는 기능입니다.
* 리더보드 오브젝트와 상호작용하여 사용할 수 있습니다.
  
  ![image](https://github.com/user-attachments/assets/6a19ef06-80ee-46b9-99c6-32386fc74f4a)

---

**6. 탑승물**
* 좌측 상단의 Vehicle 버튼을 눌러 탈것을 탈 수 있습니다.
* 우측에는 Preview가 보이며 우측 하단의 Save 버튼을 눌러 캐릭터에 적용시킬 수 있습니다.
* 탈것을 탑승하면 이동속도가 증가합니다.

  ![image](https://github.com/user-attachments/assets/c46f2273-fabd-4d54-997e-86c383975154)  ![image](https://github.com/user-attachments/assets/8dd140e3-25ef-44ed-84d2-94dfee6acbd7)

---

**7. NPC와 대화**
* 맵에 존재하는 NPC와 상호작용 시 대화를 할 수 있습니다.
  
  ![image](https://github.com/user-attachments/assets/b094b8a3-b23e-4376-b3ad-a0f55d5cecd9)




