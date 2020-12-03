import { TestBed } from '@angular/core/testing';

import { AnonymousguardGuard } from './anonymousguard.guard';

describe('AnonymousguardGuard', () => {
  let guard: AnonymousguardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AnonymousguardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
