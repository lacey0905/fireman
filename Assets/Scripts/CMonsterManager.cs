﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterManager : MonoBehaviour
{
    /*
        # 게임 스테이지 구조 -> 우선순위 배치

        # 게임 매니저
            게임의 시작과 패배를 감지 한다
            게임에서 얻은 재화나 시간 점수를 체크하고 저장한다
            게임이 종료 되면 게임 스토리지에 데이터를 저장시킨다

        # 몬스터 매니저
            ## CMonsterManager
                몬스터를 일정 시간마다 일정 갯수 스폰 시킨다
                경과된 시간에 따른 레벨디자인을 반영 시킨다

    
        # 플레이어

            ## CCharacterController
                키 입력을 받는다 (터치 컨트롤러 설치)
                입력 된 방향으로 이동한다
                    
            ## CCharacterState
                캐릭터의 정보를 가진다
                레벨
                체력
                경험치
                방어력
                공격력
                이동속도
                데미지 받기
                무적 상태
                체력이 0이 되면 게임 매니저에게 패배 신호를 보낸다

            ## CSkillController
                캐릭터의 스킬을 관리한다
                캐릭터는 사실 모든 스킬을 다 가지고 있고 enable / disable 하는 것이다
                스킬은 캐릭터 프리팹에 모두 다 인스턴스화 되어 있다
                각 스킬에 접근 할 수 있도록 한다
            
            # 몬스터 
                
                ## 몬스터 프리팹
                    몬스터는 콜라이더를 가진다
                    플레이어에게 트리거 되면 플레이어에게 데미지를 준다
                    데미지를 주는 쿨타임에 대한 분석이 필요하다
        
                ## CMonsterManager
                    몬스터는 계속 생성 된다
                    시간에 증가하면 몬스터 종류도 증가한다
            
                ## CChaseMonster
                    몬스터는 기본적으로 플레이어를 chase 한다
        
                ## CStraightMonster 
                    플레이어를 chase하지 않는 몬스터도 존재한다
                    특정 방향으로 직진한다

                ## CChameleonMonster
                    어떤 몬스터는 트리깅 되면 이동속도나 크기가 변한다

            # 스킬

                ## 스킬 프리팹
                    쿨타임을 가진다
                    레벨을 가진다
                    레벨당 데미지 증가량이나 범위 갯수 등이 정해져 있다
                    스킬은 CharacterState의 공격력에 영향을 받는다

            # 아이템

                ## 아이템 프리팹
                    효과를 가진다
                    CCharacterState의 데이터에 영향을 준다
                    스킬 프리팹에 영향을 준다
                    이 관계를 이어나갈 뭔가가 필요하다

            ## 아이템
                체력 아이템 -> 체력이 증가
                경험치 아이템 -> 경험치 증가 -> 경험치량이 다른 여러가지 아이템 존재함
                아이템 박스 -> 아이템을 제공하고 습득할지 안 할지 물어본다.
    

        # 상호작용 오브젝트
            체력 회복
            경험치
            아이템 습득
            무적
    
    */


}
